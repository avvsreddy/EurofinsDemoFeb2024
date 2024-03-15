using ContactManager.Common;
using System;
using System.Collections.Generic;

namespace ContactManager.Data
{
    public class ContactsEFRepository : IContactsRepository
    {
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
            throw new NotImplementedException();
        }

        public void UpdateContact(Contact contact, int contactID)
        {
            throw new NotImplementedException();
        }
    }
}
