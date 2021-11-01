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
using System.Text.RegularExpressions;

namespace WindowsFormsApp1
{
    public partial class NewUser : Form
    {
        private User user = new User();
        Bal bal;
        private bool isPicUploaded = false;
        private bool wantToUpdate = false;
        private bool isAdmin = false;
        private int updatedUserID = 0;
         
        public NewUser()
        {
            InitializeComponent();
            bal = new Bal();
        }

        public NewUser(User user , bool isAdmin = false )   
        {
            InitializeComponent();
            bal = new Bal();
            textName.Text= user.Name;
            textLogin.Text = user.Login;
            textPassword.Text= user.Password;
            textEmail.Text= user.Email;
            if(user.Gender == 'M')
            {
                GenderComboBox.SelectedIndex = 0;
            }
            else
            {
                GenderComboBox.SelectedIndex = 1;
            }
            textAddress.Text= user.Address;
            AgeNumericUpDown.Value = user.Age;

            NICmaskedTextBox1.Text= user.NIC;
            DOBdateTimePicker1.Value = user.DOB; 

            CricketCheckBox.Checked = user.IsCricket;
            HockeyCheckBox.Checked = user.Hockey ;
            ChessCheckBox.Checked = user.Chess;
            this.user.CreatedON = DateTime.Now;
            this.user.ImageName = user.ImageName;

            var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
            string projectDirectory = currentDirectory.Parent.Parent.Parent.FullName;
            string path = Path.Combine(projectDirectory + @"\img\");  //  getting dir where to save image


            pictureBox1.Image = Image.FromFile(path + user.ImageName);
            updatedUserID = bal.getUserID(user.Login, user.Email);
            // MessageBox.Show(user.ImageName);
            wantToUpdate = true;
            isPicUploaded = true;
            this.isAdmin = isAdmin;

        }


        // Name ,Login, Password ,Email, Gender  ,Address ,Age ,NIC ,DOB ,IsCricket,Hockey,Chess  ,ImageName ,CreatedON
        public char getGender()
        {
            if (GenderComboBox.Text == "Male")  { return 'M'; }
            else if(GenderComboBox.Text == "Female")  { return 'F'; }
            else   { return ' ';   }
        }
         
        // Name ,Login, Password ,Email, Gender  ,Address ,Age ,NIC ,DOB ,IsCricket,Hockey,Chess  ,ImageName ,CreatedON

         
        private bool isValidData() 
        {
            string pattern;            

            if (textName.Text.Trim().Length < 1)
            {
                MessageBox.Show("Name is missing");
                return false;
            }
            if (textLogin.Text.Trim().Length < 1) 
            {
                MessageBox.Show("Login is mising");
                return false;
            }
            if (textPassword.Text.Trim().Length < 5)
            {
                MessageBox.Show("Password must contain 5 or more characters");
                return false;
            }
             
            pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!Regex.IsMatch(textEmail.Text.Trim(), pattern))
            {
                MessageBox.Show("Iccorrect Email sysntax");
                return false;
            }

            
            if (getGender() ==  ' ')
            {
                MessageBox.Show("Select Gender");
                return false;
            }
            if (textAddress.Text.Trim().Length < 1)
            {
                MessageBox.Show("Address is missing");
                return false;
            }

            pattern = @"^[0-9]{5}-[0-9]{7}-[0-9]$"; 
            if (!Regex.IsMatch(NICmaskedTextBox1.Text, pattern))
            { 
                MessageBox.Show("Invalid CNIC");
                return false;
            }

            if (!isPicUploaded)
            {
                MessageBox.Show("Upload Picture");
                return false;
            }
            bool isUserAlreadyExist = bal.IsUserAlreadyExist(textLogin.Text.Trim(), textEmail.Text.Trim());
            if (isUserAlreadyExist && (!wantToUpdate) )
            {
                MessageBox.Show("User Already Exist");
                return false;
            }

            return true;
        }
         
        private void CreateBtn_Click(object sender, EventArgs e)
        {
            if (!isValidData())    {   return;   }        
             
            user.Name = textName.Text.Trim();
            user.Login = textLogin.Text.Trim();
            user.Password = textPassword.Text.Trim();
            user.Email = textEmail.Text.Trim();
            user.Gender = getGender();
            user.Address = textAddress.Text.Trim();
            user.Age = Convert.ToInt32( AgeNumericUpDown.Value);
            user.NIC = NICmaskedTextBox1.Text;
            user.DOB =  (DateTime)DOBdateTimePicker1.Value;
            user.IsCricket = CricketCheckBox.Checked;
            user.Hockey = HockeyCheckBox.Checked;
            user.Chess = ChessCheckBox.Checked;
            user.CreatedON = DateTime.Now;

            if(wantToUpdate)
            {

                bal.updateUser(this.user, updatedUserID);
            }
            else
            {
                bal.insertUser(this.user);
            } 

            if(this.isAdmin == true)
            {
                this.Hide();
                AdminHome adminHome = new AdminHome();
                adminHome.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                Home home = new Home(this.user);
                home.ShowDialog();
                this.Close();
            }                
        }

        private void NewUser_Load(object sender, EventArgs e)
        {
            // CreateBtn.Enabled = false;
        }

        private void UploadBtn_Click(object sender, EventArgs e)
        {
             
            string fileSourec;
            OpenFileDialog open = new OpenFileDialog();
            open.Filter = "Image Files(*.jpg; *.jpeg; *.gif; *.png; ) | *.jpg; *.jpeg; *.gif; *.png; ";
            if (open.ShowDialog() == DialogResult.OK)
            {
                fileSourec = open.FileName;
                pictureBox1.Load(open.FileName);

                var currentDirectory = new DirectoryInfo(AppDomain.CurrentDomain.BaseDirectory);
                string projectDirectory = currentDirectory.Parent.Parent.Parent.FullName;
                string path = Path.Combine(projectDirectory + @"\img\");  //  getting dir where to save image

                
                string filename = Path.GetFileName(fileSourec);
                string path1 = Path.Combine(path + filename);  // append path + filename
                File.Copy(fileSourec, path1, true);  // take ( source , destination , ovvrride_previous)
                

                user.ImageName = filename; //  save file name in user object
                // MessageBox.Show("image saved");
                isPicUploaded = true;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            if (this.isAdmin == true)
            {

                this.Hide();
                AdminHome adminHome = new AdminHome();
                adminHome.ShowDialog();
                this.Close();

            }
            else if (wantToUpdate)
            {
                this.Hide();
                Home home = new Home(this.user);
                home.ShowDialog();
                this.Close();
            }
            else
            {
                this.Hide();
                MainScreen home = new MainScreen();
                home.ShowDialog();
                this.Close();
            }
        }
    }
}
