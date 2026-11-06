public class ContactController
{
    private readonly ContactRepository _repository;
    private readonly ContactView _view;

    public ContactController(ContactRepository repository, ContactView view)
    {
        _repository = repository;
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
        if (string.IsNullOrWhiteSpace(name))
        {
            _view.ShowMessage("Името не може да е празно.");
            return;
        }
        string phone = _view.Ask("Телефон");
        _repository.Add(new Contact { Name = name, Phone = phone });
        _view.ShowMessage("Контактът е добавен.");
    }

    private void SearchContacts()
    {
        string text = _view.Ask("Търсене по име");
        List<Contact> found = _repository.Search(text);
        _view.ShowContacts(found);
    }

    private void ShowAllContacts()
    {
        _view.ShowContacts(_repository.GetAll());
    }

    private void DeleteContact()
    {
        string name = _view.Ask("Име за изтриване");
        if (_repository.Delete(name))
        {
            _view.ShowMessage("Контактът е изтрит.");
        }
        else
        {
            _view.ShowMessage("Няма такъв контакт.");
        }
    }
}
