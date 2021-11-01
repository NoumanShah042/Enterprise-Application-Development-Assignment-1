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
using System.IO;

namespace WindowsFormsApp1
{
    public partial class Home : Form
    {
        User user;
        public Home(User user)
        {
            InitializeComponent();
            this.user = user;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen home = new MainScreen();
            home.ShowDialog();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            NewUser newuser = new NewUser(user);
            newuser.ShowDialog();
            this.Close();

        }

        private void Home_Load(object sender, EventArgs e)
        {
            welcomeText.Text = $"Welcome {user.Name}";

            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string projectDirectory = currentDirectory.Parent.Parent.Parent.FullName;
            string path = Path.Combine(projectDirectory + @"\img\");  //  getting dir where to save image


            pictureBox1.Image = Image.FromFile(path+ user.ImageName );
        }
    }
}
