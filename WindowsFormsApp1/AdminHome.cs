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
    public partial class AdminHome : Form
    {
        Bal bal = new Bal();
        User user = new User();
        int userId;
        public AdminHome()
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

        private void AdminHome_Load(object sender, EventArgs e)
        {
            List<User> allUsers = new List<User>();
            allUsers = bal.GetAllStudents();
            dataGridView1.DataSource = allUsers;
        }

         
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if(dataGridView1.Columns[e.ColumnIndex].Name =="Edit")
            {
                this.userId = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
                this.user = bal.GetUserByID(this.userId);
                // MessageBox.Show(this.user.ToString());

                this.Hide();
                NewUser newUser = new NewUser(this.user,true );
                newUser.ShowDialog();
                this.Close();
            }

        }
    }
}
