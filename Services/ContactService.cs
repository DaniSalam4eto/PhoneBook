public class ContactService
{
    private readonly ContactRepository _repository;

    public ContactService(ContactRepository repository)
    {
        _repository = repository;
    }

    public bool IsValidName(string name)
    {
        return !string.IsNullOrWhiteSpace(name);
    }

    public void AddContact(string name, string phone)
    {
        _repository.Add(new Contact { Name = name, Phone = phone });
    }

    public List<Contact> SearchContacts(string text)
    {
        return _repository.Search(text);
    }

    public List<Contact> GetAllContacts()
    {
        return _repository.GetAll();
    }

    public bool DeleteContact(string name)
    {
        return _repository.Delete(name);
    }
}
