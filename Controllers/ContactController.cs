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
                case "0": running = false; break;
                default: _view.ShowMessage("Невалиден избор."); break;
            }
        }
    }

    private void AddContact()
    {
        string name = _view.Ask("Име");
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
}
