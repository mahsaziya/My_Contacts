using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using My_Contacts.Reposetory;
using System.Data.SqlClient;

namespace My_Contacts.Services
{
    class ContactsRepository : IContactsReposetory
    {
        private string connectionString = "Data sourse =MAHSA ; Initial Catalog=Contacts_DB; Integreted Security=true";
        public bool Delete(int ContactID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string Name, string Family, string Mobile, string Email, string Adress)
        {
            throw new NotImplementedException();
        }

        public DataTable SelectAll()
        {
            string query = "Select * From My_Contacts";
            SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter(query, connectionString);
            DataTable data = new DataTable();
            adapter.Fill(data);
            return (data);
        }
    

        public DataTable SelectRow(int ContactID)
        {
            throw new NotImplementedException();
        }

        public bool Update(int ContactID, string Name, string Family, string Mobile, string Email, string Adress)
        {
            throw new NotImplementedException();
        }
    }
}
