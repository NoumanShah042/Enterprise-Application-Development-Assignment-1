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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void adminBtn_Click(object sender, EventArgs e)
        {
            //AdminHome

            this.Hide();
            AdminHome adminHome = new AdminHome();
            adminHome.ShowDialog();
            this.Close();
        }

        private void XML_Btn_Click(object sender, EventArgs e)
        {

            this.Hide();
            XML_Data xmlFile = new XML_Data( );
            xmlFile.ShowDialog();
            this.Close();
        }
    }
}
