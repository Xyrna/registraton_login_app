using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace registraton_login_app
{
    public partial class frmLogin : Form
    { 
        public frmLogin()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {
            new FrmRegister().Show();
            this.Hide();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (Account.Login(txtUsernameL.Text, txtPasswordL.Text))
            {
                MessageBox.Show($"Welcome, {txtUsernameL.Text}","Successfully logged into account", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Invalid credentials!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtUsernameL.Text = "";
            txtPasswordL.Text = "";
            txtUsernameL.Focus();
        }

        private void chkbxShowPass_CheckedChanged(object sender, EventArgs e)
        {
            if (chkbxShowPass.Checked)
            {
                txtPasswordL.PasswordChar = '\0';
                
            }
            else
            {
                txtPasswordL.PasswordChar = '•';
                
            }
        }
    }
}
