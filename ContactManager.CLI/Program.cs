using ContactManager.CLI;
using ContactManager.Core;


//runs the program and calls all of the segments needed 
//CLI stands for command line interface

return
    new Menu(
        new SystemConsole(),
        new ContactService(new InMemoryContactRepository()))
    .Run();