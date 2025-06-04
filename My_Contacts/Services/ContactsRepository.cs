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
        private string connectionString = "Data Source=MAHSA;Initial Catalog=Contacts_DB;Integrated Security=true";

        //private string connectionString = "Data Sourse=MAHSA;Initial Catalog=Contacts_DB;Integreted Security=true";
        public bool Delete(int ContactID)
        {
            throw new NotImplementedException();
        }

        public bool Insert(string Name, string Family, string Mobile, string Email, string Adress)
        {
            SqlConnection conection = new SqlConnection(connectionString);

            try
            {

                // برای اینکه هک نشه و کاریر دستورات کوئری وارد نکنه که بره داخل دیتا بیس و اجرا بشه اینجوری با @ به صورت پارامتری وارد میکنیم.

                string query = "Insert into My_Contacts(Name,Family,Email,Mobile,Adress)Values(@Name,@Family,@Email,@Mobile,@Adress)";
                //ما اجازه نداریم وارد بانک بشیم مثل اینه که یک جای امنیتیه که فقط مامورین خودش میتونن وارد بشن.
                //پس این دستورات رو باید به دستوری بدم که داخل بانک قرار بده که اجازه ورود به بانک رو داشته باشه
                //این کار با این دستور انجام میشه

                SqlCommand command = new SqlCommand(query, conection);
                //این دستور به پارامتر name مقدار Name رو میده و اد میکنه
                command.Parameters.AddWithValue("@Name", Name );
                command.Parameters.AddWithValue("@Family", Family);
                command.Parameters.AddWithValue("@Email", Email);
                command.Parameters.AddWithValue("@Mobile", Mobile);
                command.Parameters.AddWithValue("@Adress", Adress);
                //sqlcommand  نمیتونه خودش در رو باز کنه و ببنده پس دستورات زیر رو مینویسیم
                conection.Open();
                //کوئری رو اجرا کن
                command.ExecuteNonQuery();




                return true;
            }
            catch
            {
                return false;
            }
            finally
            {
                conection.Close();

            }
        }

        public DataTable SelectAll()
        {
            string query = "Select * From My_Contacts";
            SqlConnection connection = new SqlConnection(connectionString);
            //این دستور خودش هم کانکشن رو باز میکنه و هم میبنده
            SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
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
