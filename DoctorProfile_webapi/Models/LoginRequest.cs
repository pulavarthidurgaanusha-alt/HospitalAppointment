using System.ComponentModel.DataAnnotations;

namespace HospitalAppointment.Models
{
    public class LoginRequest
    {

        [Required]
        [EmailAddress]
        [RegularExpression(@"^[A-Za-z][A-Za-z0-9._%+-]*@[A-Za-z0-9.-]+\.[A-Za-z]{2,}$",
         ErrorMessage = "Email must start with an Alphabet and should be in a valid Email-format.")]
        public string Email { get; set; }

        [Required]
        [StringLength(10, MinimumLength = 5, ErrorMessage = "Password must be between 5 and 10 characters.")]
        [RegularExpression(@"^(?=.{5,10}$)(?=[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':""\\|,.<>\/?]).*$",
         ErrorMessage = "Password should: " +
            "1. start with an UPPERCASE letter,  " +
            "2. contain at least one numeric value, " +
            "3. have atleast one special character. ")]

        public string Password { get; set; }


        [Required]


        public string Role { get; set; }
    }
}

