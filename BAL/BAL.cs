using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Entities;

namespace BAL
{
    public class Bal
    {
        Dal dal = new Dal();
        public User GetUserByID(int id)
        {
            User user = new User();

            user = dal.GetUserByID(id);
            return user;
        }

        public bool insertUser(User user)
        {

            bool isInserted = dal.insertUser(user);
            return isInserted;
        }

        public bool updateUser(User user, int Userid)
        {

            bool isUpdated = dal.updateUser(user, Userid);
            return isUpdated;
        }

        public bool IsUserAlreadyExist(string login, string email)
        {

            bool isExist = dal.IsUserAlreadyExist(login, email);
            return isExist;
        }

        public int getUserID(string login, string email)
        {

            return dal.getUserID(login, email);
        }
        public User GetUserByLogin(string Login, string Password, ref bool isValid)
        {

            return dal.GetUserByLogin(Login, Password, ref isValid);
        }

        public bool isEmailExist(string email, ref User user)
        {

            return dal.isEmailExist(email, ref user);
        }

        public bool updatePassword(string email, string newPassword)
        {

            return dal.updatePassword(email, newPassword);

        }


        public bool isValidAdmin(string login, string password)
        {
            return dal.isValidAdmin(login,password);
        }

        public List<User> GetAllStudents()
        {
            return dal.GetAllStudents();
        }
    }
}
