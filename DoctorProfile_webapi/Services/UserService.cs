
using HospitalAppointment.Auth;
using HospitalAppointment.Models;
using HospitalAppointment.Repository;
//using Microsoft.AspNetCore.Identity.Data;
using NuGet.Protocol.Core.Types;
using static webapi.NewFolder2.Exceptions;

namespace HospitalAppointment.Services
{
    public class UserService : IUserService
    {
        public readonly IUser repo;
        public readonly ITokenService _tokenService;
        public UserService(IUser userrepo,ITokenService tokenService)
        {
            repo = userrepo;
            _tokenService = tokenService;
        }

        public string Register(User user)
        {
            if (repo.Exists(user.Email))
                return "Email or phone already registered";

            repo.Register(user);
            return "User registered successfully";
        }

        public string Login(LoginRequest request)

        {

            var user = repo.GetByCredentials(request.Email, request.Password, request.Role);

            return user == null ? null : _tokenService.CreateToken(user);
        }


        public List<User> GetAllUsers()
        {

            return repo.GetAllUsers();
        }
        
        //public int AddUser(User user)
        //{
        //    if (repo.GetAllUsers(user.UserId) != null)
        //    {
        //        throw new UserIdAlreadyExistsException($"user with user id {user.UserId} already exists");
        //    }
        //    return repo.AddUser(user);
        //}
        public int DeleteUser(int id)
        {
            if (repo.GetUserById(id) == null)
            {

                throw new UserIdAlreadyExistsException($"User with user id {id} does not exists");
            }
            return repo.DeleteUser(id);
        }
        public User GetUserById(int id) { return repo.GetUserById(id); }
        public int UpdateUser(int id, User user)
        {
            if(repo.GetUserById(id) == null)
            {
                throw new UserIdAlreadyExistsException();
            }
            return repo.UpdateUser(id, user);
        }

    }
}

        
    

