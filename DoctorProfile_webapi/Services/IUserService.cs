using HospitalAppointment.Models;
//using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
//using webapi.Model;
//using webapi.Models;

namespace HospitalAppointment.Services
{
    public interface IUserService
    {
        string Register(User us);
        string Login(LoginRequest usLog);
        List<User> GetAllUsers();
            //int AddUser(User user);
            User GetUserById(int id);
            int UpdateUser(int id, User updatedUser);
            int DeleteUser(int id);
    }


}


