using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
     
namespace WindowsFormsApp1
{
    public partial class XML_Data : Form
    {
        public XML_Data()
        {
            InitializeComponent();
        }

        private void LogoutBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen home = new MainScreen();
            home.ShowDialog();
            this.Close();
        }

        private void XML_Data_Load(object sender, EventArgs e)
        {
            DataSet dataSet = new DataSet();
            dataSet.ReadXml(@"D:\7th semester books\EAD\Projects\Assignment\user.xml");
            dataGridView1.DataSource = dataSet.Tables[0];

        }
    }
}
