using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointment.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        //[Required]
        //public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public string Phone { get; set; }


        [Required]
        public UserRole Role { get; set; } // patient, doctor

        public DateTime CreatedAt { get; set; } = DateTime.Now;


        public enum UserRole
        {
            Admin,
            Doctor,
            Patient
        }

    

    }
}
