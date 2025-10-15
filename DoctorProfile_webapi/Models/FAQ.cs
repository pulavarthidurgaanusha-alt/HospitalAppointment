using System;
using System.ComponentModel.DataAnnotations;

namespace HospitalAppointment.Models
{
    public class FAQ
    {
        [Key]
        public int FaqId { get; set; }

        [Required]
        [MaxLength(100)]
        public string Question { get; set; }

        [Required]
        
        public string Answer { get; set; }

        [Required]
        [MaxLength(255)]
        public string Category { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}