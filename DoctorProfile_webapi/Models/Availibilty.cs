using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointment.Models
{
    public class Availability
    {
        [Key]
        public int AvailabilityId { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        [ForeignKey("Location")]
        public int LocationId { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan EndTime { get; set; }

        public AvailabilityStatus Status { get; set; } // available, unavailable

        public Doctor Doctor { get; set; }
        public Location Location { get; set; }


        public enum AvailabilityStatus
        {
            Available,
            Unavailable
        }

    }
}