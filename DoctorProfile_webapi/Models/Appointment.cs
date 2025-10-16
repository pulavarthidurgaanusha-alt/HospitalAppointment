using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointment.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
        // public  Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        //public required Doctor Doctor { get; set; }

        [ForeignKey("Availability")]
        public int AvailabilityId { get; set; }
        //public Availability Availability { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime AppointmentDate { get; set; }

        [Required]
        public TimeSpan AppointmentTime { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [MaxLength(255)]
        public string Concern { get; set; } // Optional field for reason to visit

        public enum AppointmentStatus
        {
            Booked,
            Completed,
            CancelledByPatient,
            CancelledByDoctor
        }
    }
}
