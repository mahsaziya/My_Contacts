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
            if (DialogResult ==DialogResult.OK)
            {
                BindGrid();
            }
        }
    }
}
