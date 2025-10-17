
//using webapi.Models;


using HospitalAppointment.Models;

namespace HospitalAppointment.Repository
    {
        public interface IUser
        {
        bool Exists(string email);
        void Register(User us1);
       
        List<User> GetAllUsers();
            //int AddUser(User user);
            User GetUserById(int id);
        User GetUserByEmail(string email);
            int UpdateUser(int id, User user);
            int DeleteUser(int id);
        User GetByCredentials(string email, string password, object role);
    }
    }


