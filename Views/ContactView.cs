public class ContactView
{
    public void ShowMenu()
    {
        Console.WriteLine("1. Добави контакт");
        Console.WriteLine("2. Търси контакт");
        Console.WriteLine("0. Изход");
        Console.WriteLine("Избор: ");
    }

    public string ReadChoice()
    {
        return Console.ReadLine() ?? "";
    }

    public string Ask(string prompt)
    {
        Console.Write(prompt + ":");
        return Console.ReadLine() ?? "";
    }

    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public void ShowContacts(List<Contact> contacts)
    {
        if (contacts.Count == 0)
        {
            Console.WriteLine("Няма намерени контакти");
            return;
        }

        foreach (Contact contact in contacts)
        {
            Console.WriteLine(contact.Name + " - " + contact.Phone);
        }
    }
}
