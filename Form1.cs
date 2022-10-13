using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registraton_login_app
{
    public partial class FrmRegister : Form
    {
        public FrmRegister()
        {
            InitializeComponent();
        }

        


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRegister_Click(object sender, EventArgs e)
        {

            if (txtUsername.Text == "" || txtPassword.Text == "" || txtConfirm.Text == "")
            {
                MessageBox.Show("Please fill all fields!", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            else if(txtUsername.Text == Class1.login1 || txtUsername.Text == Class1.login2)
            {
                MessageBox.Show("Account with this username is already created! Please, create another username", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfirm.Text = "";
                txtUsername.Text = "";
                txtUsername.Focus();
            }
            else if ((txtPassword.Text == txtConfirm.Text) && txtUsername.Text != Class1.login1 )
            {
                Class1.login2 = txtUsername.Text;
                Class1.pass2 = txtPassword.Text;

               
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtConfirm.Text = "";

                MessageBox.Show("Your account has been succesfully created!", "Registration Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Passwords do not match, Please Re-Enter", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfirm.Text = "";
                txtPassword.Focus();
            }

        }

        private void chkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxShowPass.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirm.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '•';
                txtConfirm.PasswordChar = '•';
            }

        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsername.Text = "";
            txtPassword.Text = "";
            txtConfirm.Text = "";
            txtUsername.Focus();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new frmLogin().Show();
            this.Hide();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }
    }
}
