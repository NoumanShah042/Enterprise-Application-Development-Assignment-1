using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;
using BAL;

namespace WindowsFormsApp1
{
    public partial class AdminLogin : Form
    {
        public AdminLogin()
        {
            InitializeComponent();
        }

        /*
         textLogin;
            textPassword;
            LoginBtn
                ; CancelBtn
         
         
         */
        private void LoginBtn_Click(object sender, EventArgs e)
        {
            Bal bal = new Bal();
            string login = textLogin.Text.Trim();
            string password = textPassword.Text.Trim();
            if (login=="" || password=="")
            {
                MessageBox.Show("Enter Credentials", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if ( bal.isValidAdmin(login, password))
            {
                this.Hide();
                Admin admin = new Admin();
                admin.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Enter Credentials", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
               
            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen home = new MainScreen();
            home.ShowDialog();
            this.Close();
        }
    }
}
