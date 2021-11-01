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
using System.Text.RegularExpressions;
using System.Net;
using System.Web;
using System.Net.Mail;

namespace WindowsFormsApp1
{
    public partial class Login : Form
    {
        Bal bal = new Bal();
        private int authenticationCode ;
        public Login()
        {
            InitializeComponent();
            authenticationCode = GenerateRandomNumber();
        }

        private bool SendEmail(string senderEmail, string senderEmailPassword, string receiverEmail, int code)
        {
            try
            {
                // from , to , subject , bodt
                MailMessage message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress(senderEmail);
                message.To.Add(new MailAddress(receiverEmail));
                message.Subject = "Test";
                message.Body = $"Your Verification Code is {code}";

                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(senderEmail, senderEmailPassword);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

                smtp.Send(message);
                return true;

                // enable Less secure app access in case of error
                // https://www.google.com/settings/security/lesssecureapps

            }
            catch (Exception)
            {

                return false;
            }

        }

        public int GenerateRandomNumber()
        {
            int minimum = 1000;
            int maximun = 9999;
            Random random = new Random();
            return random.Next(minimum, maximun);
        }

        private void LoginBtn_Click(object sender, EventArgs e)
        {
            string loginText = textLogin.Text.Trim();
            string PasswordText = textPassword.Text.Trim();
            bool isValid = false;

            if (PasswordText == "" || loginText == "")
            {
                MessageBox.Show("Enter Credentials","FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            User user = bal.GetUserByLogin(loginText, PasswordText, ref isValid);
            if(!isValid)
            {
                MessageBox.Show("Invalid Credentials", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.Hide();
            Home home = new Home(user);
            home.ShowDialog();
            this.Close();

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            MainScreen home = new MainScreen();
            home.ShowDialog();
            this.Close();
        }

        private void ResetBtn_Click(object sender, EventArgs e)
        { 
            if ( textEmail.Text.Trim() == "")
            {
                MessageBox.Show("Email Missing", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string pattern = "^([0-9a-zA-Z]([-\\.\\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\\w]*[0-9a-zA-Z]\\.)+[a-zA-Z]{2,9})$";
            if (!Regex.IsMatch(textEmail.Text.Trim(), pattern))
            {
                MessageBox.Show("Iccorrect Email sysntax", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return  ;
            }


            User user = new User();
            bool isExist =  bal.isEmailExist(textEmail.Text.Trim(), ref user);
            if(isExist)
            {
                bool isSend = SendEmail("senderEmail", "Password", textEmail.Text, authenticationCode);
                if (!isSend)
                {
                    MessageBox.Show("Error Sending Email", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.Hide();
                    MainScreen home = new MainScreen();
                    home.ShowDialog();
                    this.Close();
                }
                else
                {
                    this.Hide();
                    EnterResetCode resetCode = new EnterResetCode(user, authenticationCode);
                    resetCode.ShowDialog();
                    this.Close();

                }
               
            }
            else
            {
                MessageBox.Show("Email not Exist", "FAILURE", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

        }
    }
}
