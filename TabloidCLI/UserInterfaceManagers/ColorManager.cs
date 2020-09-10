using System;
using System.Collections.Generic;
using System.Text;

namespace TabloidCLI.UserInterfaceManagers
{

    public class ColorManager : IUserInterfaceManager
    {
        private readonly IUserInterfaceManager _parentUI;

        public ColorManager(IUserInterfaceManager parentUI, string connectionString)
        {
            _parentUI = parentUI;

        }
            public IUserInterfaceManager Execute()
        {
            Console.WriteLine("Background Color Menu");
            Console.WriteLine(" 1) Blue");
            Console.WriteLine(" 2) White");
            Console.WriteLine(" 3) Red");
            Console.WriteLine(" 4) Black");
            Console.WriteLine(" 5) Gray");
            Console.WriteLine(" 6) Green");
            Console.WriteLine(" 7) Yellow");
            Console.WriteLine(" 8) Magenta");
            Console.WriteLine(" 0) Go Back");

            Console.Write("> ");
            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.BackgroundColor = ConsoleColor.Cyan;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    return this;
                case "2":
                    Console.BackgroundColor = ConsoleColor.White;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    return this;
                    
                    
                case "3":
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    return this;
                case "4":
                    Console.BackgroundColor = ConsoleColor.Black;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    return this;
                case "5":
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    return this;
                case "6":
                    Console.BackgroundColor = ConsoleColor.Green;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    return this;
                case "7":
                    Console.BackgroundColor = ConsoleColor.Yellow;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Clear();
                    return this;
                case "8":
                    Console.BackgroundColor = ConsoleColor.Magenta;
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Clear();
                    return this;
                case "0":
                    return _parentUI;
                default:
                    Console.WriteLine("Invalid Selection");
                    return this;
            }

        }
    }
}
