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

        private string captcha = "";
        private Random random = new Random();
        public FrmRegister()
        {
            InitializeComponent();
        }

        
        private void updateCaptcha()
        {
            string captcha = "";
            for (int i = 0; i < random.Next(6, 10); i++)
            {
                if (random.Next(2) % 2 == 0)
                {
                    captcha += char.ConvertFromUtf32(random.Next(65, 91));
                    continue;
                }
                captcha += char.ConvertFromUtf32(random.Next(48, 58));
            }
            this.captcha = captcha;
            label4.Text = captcha;
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

            else if ((txtPassword.Text == txtConfirm.Text) && !Account.AccountExists(txtUsername.Text) )
            {
                if(textBox1.Text != captcha)
                {
                    MessageBox.Show("Captcha is incorrect!", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    updateCaptcha();
                    textBox1.Text = "";
                    textBox1.Focus();
                    return;
                }
                Account.RegisterAccount(txtUsername.Text, txtPassword.Text);

               
                txtUsername.Text = "";
                txtPassword.Text = "";
                txtConfirm.Text = "";

                MessageBox.Show("Your account has been succesfully created!", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else if(Account.AccountExists(txtUsername.Text))
            {
                MessageBox.Show("Account with this username is already created! Please, create another username", "Registration failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfirm.Text = "";
                txtUsername.Text = "";
                txtUsername.Focus();
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
            updateCaptcha();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            updateCaptcha();
        }

        private void txtUsername_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
