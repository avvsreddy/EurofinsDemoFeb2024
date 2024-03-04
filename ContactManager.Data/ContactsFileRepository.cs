using ContactManager.Common;
using System;
using System.Collections.Generic;
using System.IO;

namespace ContactManager.Data
{
    public class ContactsFileRepository : IContactsRepository
    {

        private readonly string file = "contacts.txt";

        public void DeleteContactByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Contact> GetAllContacts()
        {
            throw new NotImplementedException();
        }

        public Contact GetContactByID(int id)
        {
            throw new NotImplementedException();
        }

        public void Save(Contact contact)
        {
            using (StreamWriter writer = new StreamWriter(file, true))
            {
                // contact => CSV    111,ramesh,ramesh@gmai.com,23434234,bangalore
                string contactCsv = $"{contact.ContactID},{contact.Name},{contact.Mobile},{contact.Email},{contact.Loation}";

                writer.WriteLine(contactCsv);
            }
        }

        public void UpdateContact(Contact contact, int contactID)
        {
            throw new NotImplementedException();
        }
    }
}
