public class ContactController
{
    private readonly ContactService _service;
    private readonly ContactView _view;

    public ContactController(ContactService service, ContactView view)
    {
        _service = service;
        _view = view;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            _view.ShowMenu();
            string choice = _view.ReadChoice();
            switch (choice)
            {
                case "1": AddContact(); break;
                case "2": SearchContacts(); break;
                case "3": ShowAllContacts(); break;
                case "4": DeleteContact(); break;
                case "0": running = false; break;
                default: _view.ShowMessage("Невалиден избор."); break;
            }
        }
    }

    private void AddContact()
    {
        string name = _view.Ask("Име");
        if (!_service.IsValidName(name))
        {
            _view.ShowMessage("Името не може да е празно.");
            return;
        }
        string phone = _view.Ask("Телефон");
        _service.AddContact(name, phone);
        _view.ShowMessage("Контактът е добавен.");
    }

    private void SearchContacts()
    {
        string text = _view.Ask("Търсене по име");
        List<Contact> found = _service.SearchContacts(text);
        _view.ShowContacts(found);
    }

    private void ShowAllContacts()
    {
        _view.ShowContacts(_service.GetAllContacts());
    }

    private void DeleteContact()
    {
        string name = _view.Ask("Име за изтриване");
        if (_service.DeleteContact(name))
        {
            _view.ShowMessage("Контактът е изтрит.");
        }
        else
        {
            _view.ShowMessage("Няма такъв контакт.");
        }
    }
}
