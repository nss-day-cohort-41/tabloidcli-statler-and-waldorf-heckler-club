using TabloidCLI.UserInterfaceManagers;
using System;

namespace TabloidCLI
{
    class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine(@"╔════╗─╔╗─╔╗──────╔╦═══╦╗──╔══╗
                                ║╔╗╔╗║─║║─║║──────║║╔═╗║║──╚╣╠╝
                                ╚╝║║╠╩═╣╚═╣║╔══╦╦═╝║║─╚╣║───║║
                                ──║║║╔╗║╔╗║║║╔╗╠╣╔╗║║─╔╣║─╔╗║║
                                ──║║║╔╗║╚╝║╚╣╚╝║║╚╝║╚═╝║╚═╝╠╣╠╗
                                ──╚╝╚╝╚╩══╩═╩══╩╩══╩═══╩═══╩══╝");
            Console.WriteLine("");

            Console.WriteLine("Welcome to TabloidCLI");
            Console.WriteLine("");

            // MainMenuManager implements the IUserInterfaceManager interface
            IUserInterfaceManager ui = new MainMenuManager();
            while (ui != null)
            {
                // Each call to Execute will return the next IUserInterfaceManager we should execute
                // When it returns null, we should exit the program;
                ui = ui.Execute();
            }
        }
    }
}
