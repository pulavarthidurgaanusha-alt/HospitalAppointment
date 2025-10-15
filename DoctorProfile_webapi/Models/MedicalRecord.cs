using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointment.Models
{
    public class MedicalRecord
    {
        [Key]
        public int RecordId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public string Concern { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }

        public string Description { get; set; }

        public string Prescription { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Patient Patient { get; set; }
        public Doctor Doctor { get; set; }
    }
}