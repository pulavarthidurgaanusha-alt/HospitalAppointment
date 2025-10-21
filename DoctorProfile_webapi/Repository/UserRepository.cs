using HospitalAppointment.Repository;
using System;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
//using webapi.Data;

//using webapi.Models;
//using webapi.Services;
using static webapi.NewFolder2.Exceptions;
//using static webapi.Repository.UserRepository;

namespace HospitalAppointment.Repository
{
    public class UserRepository : IUser

    {
        private readonly Appointment_BookingContext _context;


        public UserRepository(Appointment_BookingContext context)
        {
            _context = context;

        }
        public bool Exists(string email)
        {
            return _context.User.Any(u => u.Email == email );
        }

        public void Register(User us1)
        {
            _context.User.Add(us1);
            _context.SaveChanges();
        }

        public User GetByCredentials(string email, string password, string role)
        {
            var user = _context.User.FirstOrDefault(u =>
                u.Email == email && u.Role == role);

            if (user == null)
                return null;

            return user;
        }

        public List<User> GetAllUsers()
        {

            return _context.User.ToList();
        }
        //public int AddUser(User user)
        //{
        //    _context.User.Add(user);
        //    return _context.SaveChanges();

        //}
        public User GetUserById(int id)
        {
            return _context.User.FirstOrDefault(s => s.UserId == id);
        }
        public User GetUserByEmail(string email)
        {
            return _context.User.FirstOrDefault(x => x.Email == email);
        }

        public int UpdateUser(int id, User user)
        {

            var existingUser = _context.User.Find(id);
            if (existingUser == null)
            {
                throw new UserNotFoundException($"User with user id {id} does not exist");
            }


            existingUser.Email = user.Email;

            existingUser.Role = user.Role;

            return _context.SaveChanges();

        }


        public int DeleteUser(int id)
        {
            var existingUser = _context.User.Find(id);
            if (existingUser == null)
            {
                throw new UserNotFoundException($"User with user id {id} does not exist");
            }

            _context.User.Remove(existingUser);
            return _context.SaveChanges();
        }

        User IUser.GetByCredentials(string email, string password, object role)
        {
            throw new NotImplementedException();
        }

        //public List<User> GetAllUsers(string email)
        //{
        //    throw new NotImplementedException();
        //}
    }
}



