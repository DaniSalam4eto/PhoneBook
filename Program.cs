using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
var repository = new ContactRepository();
var service = new ContactService(repository);
var view = new ContactView();
var controller = new ContactController(service, view);
controller.Run();
