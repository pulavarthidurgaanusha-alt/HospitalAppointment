using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointment.Models
{
    public class Rating
    {
        [Key]
        public int RatingId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public int Value { get; set; }
        public string Feedback { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Doctor Doctor { get; set; }
        //public Patient Patient { get; set; }
    }
}