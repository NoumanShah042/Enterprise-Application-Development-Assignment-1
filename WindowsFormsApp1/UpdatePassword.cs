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
    public partial class UpdatePassword : Form
    {
        User user;
        public UpdatePassword(User user)
        {
            this.user = user;
            InitializeComponent();
        }

        private void UpdateBtn_Click(object sender, EventArgs e)
        {
            if (newPassword.Text.Trim().Length < 5)
            {
                MessageBox.Show("Password must contain 5 or more characters");
            }
            else
            {
                Bal bal = new Bal();
                bal.updatePassword(user.Email, newPassword.Text.Trim());

                this.Hide();
                Home home = new Home(this.user);
                home.ShowDialog();
                this.Close();

            }
        }
    }
}
