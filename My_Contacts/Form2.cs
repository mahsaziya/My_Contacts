using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using My_Contacts.Reposetory;
using My_Contacts.Services;

namespace My_Contacts
{
    public partial class Form2 : Form
    {
        IContactsReposetory repository;

        public Form2()
        {
            InitializeComponent();
            repository = new ContactsRepository();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            BindGrid();


        }

        private void BindGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.DataSource = repository.SelectAll();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void btnNweContact_Click(object sender, EventArgs e)
        {
            FormAddOrEdit form = new FormAddOrEdit();
            form.ShowDialog();
            if (DialogResult == DialogResult.OK)
            {
                BindGrid();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string name = dataGridView1.CurrentRow.Cells[1].Value.ToString();
                string family = dataGridView1.CurrentRow.Cells[2].Value.ToString();
                string fulname = name + " " + family;
                DialogResult res = MessageBox.Show($"آیا میخواهید {fulname} را حذف کنید ؟ ", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning); ;
                if ( res== DialogResult.Yes)
                {
                    int ContactID = int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                    repository.Delete(ContactID);
                    MessageBox.Show("عملیات با موفقیت انجام شد.");
                    BindGrid();
                }


            }
            else
            {
                MessageBox.Show("لطفا یک شخص را انتخاب کنید", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if(dataGridView1.CurrentRow!=null)
            {

                int contactsiD= int.Parse(dataGridView1.CurrentRow.Cells[0].Value.ToString());
                FormAddOrEdit Form = new FormAddOrEdit();
                Form.contactid = contactsiD;
                if (Form.ShowDialog() == DialogResult.OK)
                {
                    BindGrid();
                }

            }
            else
            {
                MessageBox.Show("لطفا یک کاربر را انخاب کنید ", " Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            dataGridView1.DataSource = repository.Search(textBox1.Text);
          
        }
    }
}
