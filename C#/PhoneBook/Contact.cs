using System;
using System.Collections.Generic;
using System.Text;

namespace Contacts
{
    class Contact
    {
        private string _name;
        private string _phoneNumber;

        public string Name {
            get
            {
                return _name;
            }
            set
            {

               _name = value;

            } 
        }

        public string PhoneNumber
        {
            get
            {
                return _phoneNumber;
            }
            set
            {

                _phoneNumber = value;
            }
        }

        public Contact()
        {
            Name = "Jan Kowalski";
            PhoneNumber = "123456789";
        }

        public Contact(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
}
