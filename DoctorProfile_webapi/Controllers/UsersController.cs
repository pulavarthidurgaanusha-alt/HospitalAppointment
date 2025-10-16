//using System;
//using System.Collections.Generic;
//using System.Linq;
using HospitalAppointment.Models;
using HospitalAppointment.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
//using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
//using webapi.Data;
//using webapi.Model;
//using webapi.Models;
//using webapi.Repository;
//using webapi.Services;

namespace HospitalAppointment.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]

        public IActionResult Register([FromBody] User us)

        {
            if (string.IsNullOrWhiteSpace(us.Role))
            {
                return BadRequest("Role is required.");
            }

           
            var roleInput = us.Role.Trim();

          
            var allowedRoles = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        "Doctor", "Patient", "Admin"
    };

            if (allowedRoles.Contains(roleInput))
            {
             
                us.Role = char.ToUpper(roleInput[0]) + roleInput.Substring(1).ToLower();

                var result = _userService.Register(us);

                if (result.Contains("already"))
                    return Conflict(result);

                return StatusCode(201, result);
            }
            else
            {
                return BadRequest("Invalid role. Allowed roles are Doctor, Patient, or Admin.");
            }
        }

        

        

        [AllowAnonymous]
        [HttpPost("login")]

        public IActionResult Login([FromBody] LoginRequest usLog)

        {

            var result = _userService.Login(usLog);

            if (result == "Invalid email" || result == "Invalid password" || result == "Invalid role")

                return Unauthorized(result); // returns the specific error

            return Ok(new { Token = result }); // result is the token

        }


        [Authorize(Roles = "Admin,Doctor")]
        [HttpGet]
        public IActionResult GetAllUsers()
        
            {
                var users = _userService.GetAllUsers();
                return Ok(users);
            }


        //[HttpPost]
        //public IActionResult PostUser(User user)
        //{
        //    if (user.Role== null)
        //    {
        //        return BadRequest("Role is required.");
        //    }

        //    var role = user.Role;

        //    if (role == "doctor" || role == "patient" || role == "admin")
        //    {

        //        user.Role = char.ToUpper(role[0]) + role.Substring(1); 

        //        var createdUser = _userService.AddUser(user);
        //        return StatusCode(201, createdUser);
        //    }
        //    else
        //    {
        //        return BadRequest("Invalid role. Allowed roles are Doctor, Patient, or Admin.");
        //    }
        //}
        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            var result = _userService.DeleteUser(id);
            if (result == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return NoContent();
        }
        [Authorize(Roles = "Admin,Patient")]
        [HttpPut("{id}")]
        public IActionResult UpdateUser(int id, User updatedUser)
        {
            if (updatedUser == null || string.IsNullOrEmpty(updatedUser.Email) || string.IsNullOrEmpty(updatedUser.Password))
            {
                return BadRequest("Email and Password are required.");
            }

            var result = _userService.UpdateUser(id, updatedUser);
            if (result == null)
            {
                return NotFound($"User with ID {id} not found.");
            }

            return Ok(result);
        }
    }
}

    














