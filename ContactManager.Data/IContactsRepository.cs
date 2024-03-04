using ContactManager.Common;
using System.Collections.Generic;

namespace ContactManager.Data
{
    public interface IContactsRepository
    {
        void Save(Contact contact);
        List<Contact> GetAllContacts();
        Contact GetContactByID(int id);
        void DeleteContactByID(int id);
        void UpdateContact(Contact contact, int contactID);
    }
}
