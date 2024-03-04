using ContactManager.Common;
using ContactManager.Data;
using System;

namespace ContactManager.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Contact Manager");
                Console.WriteLine("=====================");
                Console.WriteLine("1. Create Contact");
                Console.WriteLine("2. Get All Contacts");
                Console.WriteLine("3. Get Contact By ID");
                Console.WriteLine("4. Edit Contact");
                Console.WriteLine("5. Delete Contact");
                Console.WriteLine("6. Exit");
                Console.WriteLine("----------------------");
                Console.Write("Enter your choice [1-6] :");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1: CreateContact(); break;
                    case 2: GetAllContacts(); break;
                    case 3: GetContactById(); break;
                    case 4: EditContact(); break;
                    case 5: DeleteContact(); break;
                    case 6: Environment.Exit(0); break;
                    default: Console.WriteLine("Invalid option"); break;
                }

            }



        }

        private static void DeleteContact()
        {
            throw new NotImplementedException();
        }

        private static void EditContact()
        {
            throw new NotImplementedException();
        }

        private static void GetContactById()
        {
            throw new NotImplementedException();
        }

        private static void GetAllContacts()
        {
            throw new NotImplementedException();
        }

        private static void CreateContact()
        {
            Contact c = new Contact();
            Console.Write("Contact ID :");
            c.ContactID = int.Parse(Console.ReadLine());
            Console.Write("Contact Name :");
            c.Name = Console.ReadLine();
            Console.Write("Mobile No :");
            c.Mobile = Console.ReadLine();
            Console.Write("Email ID:");
            c.Email = Console.ReadLine();
            Console.Write("Location :");
            c.Loation = Console.ReadLine();

            IContactsRepository repository = new ContactsFileRepository(); // this is wrong // DIP
            repository.Save(c);
            Console.WriteLine("Contact saved successfully");
        }
    }
}
