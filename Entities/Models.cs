using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Admin
    {
        public int AdminID { get; set; }
        public string AdminName { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public Admin(int AdminId, string AdminName, string Login, string Password)
        {
            this.AdminID = AdminId;
            this.AdminName = AdminName;
            this.Login = Login;
            this.Password = Password;
        }
        public override string ToString()
        {
            return $"AdminID:{AdminID} ,  AdminName:{AdminName} ,  Login:{Login} ,  AdminID:{AdminID} ,  Password:{Password}";
        }

    }
    public class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public char Gender { get; set; }
        public string Address { get; set; }
        public int Age { get; set; }
        public string NIC { get; set; }
        public DateTime DOB { get; set; }
        public bool IsCricket { get; set; }
        public bool Hockey { get; set; }
        public bool Chess { get; set; }      
        public string ImageName { get; set; }
        public DateTime CreatedON { get; set; }

        public User()
        { 

        }

        public User(int UserId, string Name, string Login, string Password,
                string Email, char Gender, string Address, int Age,
                string NIC, DateTime DOB, bool IsCricket, bool Hockey,
                 bool Chess, string ImageName, DateTime CreatedON)
        {
            this.UserId = UserId;
            this.Name = Name;
            this.Login = Login;
            this.Password = Password;
            this.Email = Email;
            this.Gender = Gender;
            this.Address = Address;
            this.Age = Age;
            this.NIC = NIC;
            this.DOB = DOB;
            this.IsCricket = IsCricket;
            this.Hockey = Hockey;
            this.Chess = Chess;
            this.ImageName = ImageName;
            this.CreatedON = CreatedON;

        }

        public override string ToString()
        {
            return $"UserID:{UserId}, Name:{Name}, Login:{Login}, " +
                $"Password:{Password}, Email:{Email}, Gender:{Gender}, " +
                $"Address:{ Address}, Age:{ Age}, NIC:{NIC}, DOB:{DOB}, " +
                $"IsCricket:{IsCricket}, Hockey:{Hockey}, Chess:{Chess}, ImageName:{ImageName}, CreatedON:{CreatedON}";
        }

    }
}
