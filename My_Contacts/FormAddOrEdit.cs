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
    public partial class FormAddOrEdit : Form
    {
        IContactsReposetory reposetory;
        public int contactid = 0;
        public FormAddOrEdit()
        {
            InitializeComponent();
            reposetory = new ContactsRepository();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (contactid== 0)
            {
                if (ValidateInputs())
                {
                    bool isSuccess = reposetory.Insert(txtName.Text, txtFamily.Text, txtMobile.Text, txtEmail.Text, txtAdress.Text);
                    if (isSuccess == true)
                    {
                        MessageBox.Show("عملیات با موفقیت انجام شد ", "Successs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        DialogResult = DialogResult.OK;
                    }
                    else
                    {
                        MessageBox.Show("عملیات با شکست مواجه شد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                bool isSuccess = reposetory.Update(contactid, txtName.Text, txtFamily.Text, txtAdress.Text, txtMobile.Text, txtEmail.Text);
                if (isSuccess==true)
                {
                    MessageBox.Show("عملیات با موفقیت انجام شد ", "Successs", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("عملیات با شکست مواجه شد", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
           
            
        }
        bool ValidateInputs()
        {
            if (txtName.Text == "")

            {
                MessageBox.Show("لطفا نام را وارد کنید.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtFamily.Text == "")

            {
                MessageBox.Show("لطفا نام خانوادگی را وارد کنید.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtMobile.Text == "")

            {
                MessageBox.Show("لطفا موبایل را وارد کنید.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            if (txtEmail.Text == "")

            {
                MessageBox.Show("لطفا ایمیل را وارد کنید.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
          
            return true;
        }

        private void FormAddOrEdit_Load(object sender, EventArgs e)
        {
            if (contactid == 0)
            {
                this.Text = "افزودن شخص";

            }
            else
            {
                this.Text = "ویرایش";
                DataTable dt = reposetory.SelectRow(contactid);
                txtName.Text = dt.Rows[0][1].ToString();
                txtFamily.Text = dt.Rows[0][2].ToString();
                txtMobile.Text = dt.Rows[0][3].ToString();
                txtEmail.Text = dt.Rows[0][4].ToString();
                txtAdress.Text = dt.Rows[0][5].ToString();
                button1.Text = "ویرایش";


            }
        }
    }
}
