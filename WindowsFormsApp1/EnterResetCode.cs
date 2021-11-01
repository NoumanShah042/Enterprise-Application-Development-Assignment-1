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
    public partial class EnterResetCode : Form
    {
        private int authenticationCode;
        User user;
        public EnterResetCode(User user , int code )
        {
            this.user = user;
            authenticationCode = code;
            InitializeComponent();
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            string code = textCode.Text;
            string codeAsString = Convert.ToString(authenticationCode);
            if (String.Equals(code, codeAsString))
            {
                this.Hide();
                UpdatePassword updatePasword = new UpdatePassword(user);
                updatePasword.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid Code", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Hide();
                Login login = new Login( );
                login.ShowDialog();
                this.Close();
            }


        }
    }
}
