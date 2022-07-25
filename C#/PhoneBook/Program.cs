using System;
using System.Collections.Generic;

namespace Contacts
{
    class Program
    {

        

        static void Main(string[] args)
        {
            ContactManager phoneBook = new ContactManager();

            Console.WriteLine("-----------------------------\n");
            Console.WriteLine("Welcome to your contacts!");
            Console.WriteLine("What would you like to do?\n");
            Console.WriteLine("1. Add new Contact");
            Console.WriteLine("2. Search for number");
            Console.WriteLine("3. See all your Contacts");
            Console.WriteLine("4. Search for name");
            Console.WriteLine("5. Exit\n");

            string selection = "";

            while (selection != "5")
            {
                Console.Write("Your selection: ");
                selection = Console.ReadLine();
                Console.WriteLine("________________");
                Console.WriteLine("\nResult:\n");

                switch (selection)
                {
                    case "1":
                        phoneBook.AddContact();
                        break;
                    case "2":
                        phoneBook.SearchForNumberInContacts();
                        break;
                    case "3":
                        phoneBook.SeeAllContactsInContacts();
                        break;
                    case "4":
                        phoneBook.SearchForNameInContacts();
                        break;
                    case "5":
                        Console.WriteLine("Exiting...");
                        return;
                        
                    default:
                        Console.WriteLine("Wrong Input, try again...");
                        break;
                }

                Console.WriteLine("\n******************\n");
            }
        }
    }
}
