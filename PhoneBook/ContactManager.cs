using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contacts
{
    class ContactManager : Contact
    {
        private List<Contact> _contactList = new List<Contact>();

        public List<Contact> ContactList
        {
            get
            {
                return _contactList;
            }
            set
            {
                _contactList = value;
            }
        }

        public void AddContact()
        {
            string name, phoneNumber;

            while (true)
            {
                Console.Write("Name: ");
                name = Console.ReadLine();
                Console.Write("Phone Number: ");
                phoneNumber = Console.ReadLine();

                bool phoneNumberTooShort = phoneNumber.Length < 9;

                if (String.IsNullOrEmpty(name) || String.IsNullOrEmpty(phoneNumber))
                {
                    Console.WriteLine("Something went wrong, try again...");
                }
                else if (phoneNumberTooShort)
                {
                    Console.WriteLine("Phone number shold be at least 9 digits long!");
                }
                else
                {
                    break;
                }

                Console.WriteLine();
            }

            ContactList.Add(new Contact(name, phoneNumber));
        }

        public void SearchForNumberInContacts()
        {
            Console.Write("Phone Number: ");
            string phoneNumber = Console.ReadLine();

            var foundName = ContactList.FirstOrDefault(e => e.PhoneNumber == phoneNumber);

            if (foundName == null)
            {
                Console.WriteLine("Contact not found!");
            }
            else
            {
                Console.WriteLine("Name: " + foundName.Name);
            }
        }

        public void SeeAllContactsInContacts()
        {
            int i = 1;
            foreach (Contact element in ContactList)
            {
                Console.WriteLine("---------------");
                Console.WriteLine($"Contact: {i}");
                Console.WriteLine("Name " + element.Name);
                Console.WriteLine("Phone Number " + element.PhoneNumber);
                Console.WriteLine("---------------");
                i++;
            }
        }

        public void SearchForNameInContacts()
        {
            Console.Write("Name: ");
            string name = Console.ReadLine();

            var foundNumber = ContactList.FirstOrDefault(e => e.Name.Contains(name));

            if (foundNumber == null)
            {
                Console.WriteLine("Contact not found!");
            }
            else
            {
                Console.WriteLine("PhoneNumber: " + foundNumber.PhoneNumber);
            }
        }
    }
}
