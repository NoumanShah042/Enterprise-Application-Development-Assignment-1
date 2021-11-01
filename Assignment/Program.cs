using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using BAL;
using System.Data.SqlClient;



namespace Assignment
{
    class Program
    {
        
        static void Main(string[] args)
        {
            // Name ,Login, Password ,Email, Gender  ,Address ,Age ,NIC ,DOB ,IsCricket,Hockey,Chess  ,ImageName ,CreatedON
            User user = new User(2, "Nouman", "Nouman", "nomi",
                        "Nouman@gmail.com", 'M', "Address", 23,
                        "35201-6731055-3", new DateTime(1998, 11, 12), false, false,
                        false, "ImageName.png", DateTime.Now);

            Bal bal = new Bal();
            bal.insertUser(user);
            //Console.WriteLine(  );

            //foreach(User i in bal.GetAllStudents())
            //{
            //    Console.WriteLine(i);
            //    Console.WriteLine();
            //}
            //bal.updatePassword("noumanrehman042@gmail.com", "123456");

            // Console.WriteLine(bal.isValidAdmin("Nouman", "12345"));

            //User user2 = new User();
            //Console.WriteLine(bal.isEmailExist("noumanrehman042@gmail.com", ref user2)); ;
            //Console.WriteLine(user2);


            //bool isvalid= false; 
            //User user2 = bal.GetUserByLogin("shshs", "55464646", ref isvalid);
            //Console.WriteLine(isvalid);
            //Console.WriteLine(user2);

            //******************************            

            //SqlConnection con = new SqlConnection("Data Source=NOUMANSHAH;Initial Catalog=Assignment2;Integrated Security=True");
            //SqlCommand cmd;
            //SqlDataAdapter adpt;
            //SqlDataReader reader;

            //string login = "Noumsan";
            //string email = "Noumangsg@gmail.com";

            //using (con)
            //{
            //    con.Open();
            //    string query = $"select * from Users  where Login='{login}' or Email='{email}' ";
            //    cmd = new SqlCommand(query, con);
            //    reader = cmd.ExecuteReader();
            //    if (reader.Read())
            //    {
            //        Console.WriteLine("user Already Exist");

            //    }
            //    else
            //    {
            //        Console.WriteLine("New user");
            //    }
            //}



            //****************************** 
            //Console.WriteLine(bal.IsUserAlreadyExist("Nhouman", "Nouzman@gmail.com"));


            //****************************** 


            //bal.updateUser(user,16);


            //bal.insertUser(user);


            //User user2 = new User();
            //user = bal.GetUserByID(15);
            //Console.WriteLine(user);
        }

        
        
    }
}
