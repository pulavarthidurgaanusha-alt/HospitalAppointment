using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointment.Models
{
    public class Patient
    {
        [Key]
        public int PatientId { get; set; }

        [ForeignKey("User")]
        public int UserId { get; set; }
        [Required]
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [StringLength(10)]
        public string Phone { get; set; }

        public PatientGender Gender { get; set; } // Male, Female, Other

        public DateTime Dob { get; set; }

        public string Address { get; set; }

        public User User { get; set; }

        public enum PatientGender
        {
            Male,
            Female,
            Other
        }



    }
}