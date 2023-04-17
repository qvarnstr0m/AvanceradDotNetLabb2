// See https://aka.ms/new-console-template for more information
using AvanceradDotNetLabb2;
using AvanceradDotNetLabb2.Data;

Console.WriteLine("Hello, World!");

DataContext dataContext = new DataContext();
var controller = new Controllers(dataContext);
await controller.Menu();
