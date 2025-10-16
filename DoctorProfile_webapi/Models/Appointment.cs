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

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Availability")]
        public int AvailabilityId { get; set; }

        public DateTime AppointmentDate { get; set; }

        public TimeSpan AppointmentTime { get; set; }

        [Required]
        public AppointmentStatus Status { get; set; } // booked, completed, cancelled_by_patient, cancelled_by_doctor

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        //public Doctor Doctor { get; set; }
        //public Patient Patient { get; set; }
        //public Availability Availability { get; set; }


        public enum AppointmentStatus
        {
            Booked,
            Completed,
            CancelledByPatient,
            CancelledByDoctor
        }

    }
}
