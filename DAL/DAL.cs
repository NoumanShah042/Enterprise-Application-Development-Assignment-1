using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using System.Data.SqlClient; 
using System.Data;

namespace DAL
{
    public class Dal
    {
        SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True");
        SqlCommand cmd;
        SqlDataAdapter adpt;
        SqlDataReader reader;
        DataTable dt;
        public User GetUserByID(int id)
        {
            User user = new User();
            //  wrap db operation around  will automatically close the database connection
            using (SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
            {
                con.Open();
                string query = $"select * from users where UserId = {id}";
                //string query = "select * from student where id = "+id;
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader[0]);
                    user.Name = reader[1].ToString();
                    user.Login = reader[2].ToString();
                    user.Password = reader[3].ToString();
                    user.Email = reader[4].ToString();
                    user.Gender = Convert.ToChar(reader[5]);
                    user.Address = reader[6].ToString();
                    user.Age = Convert.ToInt32(reader[7]);
                    user.NIC = reader[8].ToString();
                    user.DOB = (DateTime)reader[9];
                    user.IsCricket = Convert.ToBoolean(reader[10]);
                    user.Hockey = Convert.ToBoolean(reader[11]);
                    user.Chess = Convert.ToBoolean(reader[12]);
                    user.ImageName = reader[13].ToString();
                    user.CreatedON = (DateTime)reader[14];
                 }
            }
            return user;
        }

        public bool insertUser(User user)
        {
            try {
                 
                using (SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
                {
                    con.Open();
                    string query = $"insert into Users (Name ,Login, Password ,Email, Gender  ,Address ,Age ,NIC ,DOB ,IsCricket,Hockey,Chess  ,ImageName ,CreatedON)" +
                        $" values( '{user.Name}' ,'{user.Login}' , '{user.Password}','{user.Email}', '{user.Gender}', '{user.Address}', {user.Age}, '{user.NIC}' , '{user.DOB.ToString("MM-dd-yyyy")}' , {Convert.ToInt32(user.IsCricket)},{Convert.ToInt32(user.Hockey)} , {Convert.ToInt32(user.Chess)} , '{user.ImageName}', '{user.CreatedON.ToString("MM-dd-yyyy hh:mm:ss tt")}')";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool updateUser(User user, int Userid)
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
                {
                    con.Open();
                    string query = $"update Users set Name='{user.Name}' ,Login='{user.Login}', Password='{user.Password}'" +
                        $" ,Email='{user.Email}', Gender='{user.Gender}'  ,Address='{user.Address}' ,Age={user.Age} ,NIC='{user.NIC}'" +
                        $" ,DOB='{user.DOB.ToString("MM-dd-yyyy")}' ,IsCricket={Convert.ToInt32(user.IsCricket)},Hockey= {Convert.ToInt32(user.Hockey)},Chess={Convert.ToInt32(user.Chess)}" +
                        $"  ,ImageName='{user.ImageName}' ,CreatedON='{user.CreatedON.ToString("MM-dd-yyyy hh:mm:ss tt")}'  " +
                        $"  where UserId={Userid}  ";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool updatePassword(string email, string newPassword )
        {
            try
            {
                using (SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
                {
                    con.Open();
                    string query = $"update Users set Password='{newPassword}' where Email='{email}'";
                    cmd = new SqlCommand(query, con);
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool IsUserAlreadyExist(string login , string email)
        {        
            using (SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
            {
                con.Open();
                string query = $"select * from Users  where Login='{login}' or Email='{email}' ";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }                    
        }

        public int getUserID(string login, string email)
        {
            using (SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
            {
                con.Open();
                string query = $"select * from Users  where Login='{login}' or Email='{email}' ";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    return Convert.ToInt32(reader[0]); 
                }
                else
                {
                    return -1;
                }
            }
        }

        public User GetUserByLogin(string Login, string Password , ref bool isValid)
        {
            User user = new User();
            //  wrap db operation around  will automatically close the database connection
            using (SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
            {
                con.Open();
                string query = $"select * from users where Login='{Login}' and Password='{Password}'";
                //string query = "select * from student where id = "+id;
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader[0]);
                    user.Name = reader[1].ToString();
                    user.Login = reader[2].ToString();
                    user.Password = reader[3].ToString();
                    user.Email = reader[4].ToString();
                    user.Gender = Convert.ToChar(reader[5]);
                    user.Address = reader[6].ToString();
                    user.Age = Convert.ToInt32(reader[7]);
                    user.NIC = reader[8].ToString();
                    user.DOB = (DateTime)reader[9];
                    user.IsCricket = Convert.ToBoolean(reader[10]);
                    user.Hockey = Convert.ToBoolean(reader[11]);
                    user.Chess = Convert.ToBoolean(reader[12]);
                    user.ImageName = reader[13].ToString();
                    user.CreatedON = (DateTime)reader[14];
                    isValid = true; 
                }
                else
                {
                    isValid = false;
                }
            }
            return user;
        }

       

        public bool isEmailExist(string email, ref User user)
        {
            bool isExist = false;
            using(SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
            {
                con.Open();
                string query = $"select * from users where  Email='{email}'";
                //string query = "select * from student where id = "+id;
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    user.UserId = Convert.ToInt32(reader[0]);
                    user.Name = reader[1].ToString();
                    user.Login = reader[2].ToString();
                    user.Password = reader[3].ToString();
                    user.Email = reader[4].ToString();
                    user.Gender = Convert.ToChar(reader[5]);
                    user.Address = reader[6].ToString();
                    user.Age = Convert.ToInt32(reader[7]);
                    user.NIC = reader[8].ToString();
                    user.DOB = (DateTime)reader[9];
                    user.IsCricket = Convert.ToBoolean(reader[10]);
                    user.Hockey = Convert.ToBoolean(reader[11]);
                    user.Chess = Convert.ToBoolean(reader[12]);
                    user.ImageName = reader[13].ToString();
                    user.CreatedON = (DateTime)reader[14];
                    isExist = true;

                }                 
            }
            return isExist;
        }

        public bool isValidAdmin(string login, string password) 
        {
            bool isExist = false;
            using (SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
            {
                con.Open();
                string query = $"select * from Admin  where Login='{login}' and Password='{password}' ";
                cmd = new SqlCommand(query, con);
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    isExist = true;
                }
            }
            return isExist;
        }

        public  List<User> GetAllStudents()
        {
            List<User> list = new List<User>();
            using (SqlConnection conn = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True"))
            {
                SqlCommand cmd = new SqlCommand("select * from Users", conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    User user = new User();
                    user.UserId = Convert.ToInt32(reader[0]);
                    user.Name = reader[1].ToString();
                    user.Login = reader[2].ToString();
                    user.Password = reader[3].ToString();
                    user.Email = reader[4].ToString();
                    user.Gender = Convert.ToChar(reader[5]);
                    user.Address = reader[6].ToString();
                    user.Age = Convert.ToInt32(reader[7]);
                    user.NIC = reader[8].ToString();
                    user.DOB = (DateTime)reader[9];
                    user.IsCricket = Convert.ToBoolean(reader[10]);
                    user.Hockey = Convert.ToBoolean(reader[11]);
                    user.Chess = Convert.ToBoolean(reader[12]);
                    user.ImageName = reader[13].ToString();
                    user.CreatedON = (DateTime)reader[14];
                    list.Add(user);
                }

            }

            return list;
        }
    }
}
