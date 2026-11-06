public class ContactRepository
{
    private readonly List<Contact> _contacts = new();

    public void Add(Contact contact)
    {
        _contacts.Add(contact);
    }

    public List<Contact> GetAll()
    {
        return new List<Contact>(_contacts);
    }

    public bool Delete(string name)
    {
        return _contacts.RemoveAll(contact => contact.Name.Equals(name, StringComparison.OrdinalIgnoreCase)) > 0;
    }

    public List<Contact> Search(string text)
    {
        List<Contact> result = new();
        foreach (Contact contact in _contacts)
        {
            if (contact.Name.Contains(text, StringComparison.OrdinalIgnoreCase))
            {
                result.Add(contact);
            }
        }
        return result;
    }
}
