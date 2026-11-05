using System.Text;
Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
var repository = new ContactRepository();
var view = new ContactView();
var controller = new ContactController(repository, view);
controller.Run();
