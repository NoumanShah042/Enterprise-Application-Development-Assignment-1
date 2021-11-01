using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class MainScreen : Form
    {
        public MainScreen()
        {
            InitializeComponent();
        }

         

        private void newUserBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewUser newUser = new NewUser();
            newUser.ShowDialog();
            this.Close();
        }

        private void ExistingUserBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.ShowDialog();
            this.Close();
        }

        private void AdminBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            AdminLogin admin = new AdminLogin();
            admin.ShowDialog();
            this.Close();
        }

        private void ExitBtn_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
