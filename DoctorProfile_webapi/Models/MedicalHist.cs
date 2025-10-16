using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalAppointment.Models
{
    public class MedicalHist
    {
        [Key]
        public int HistoryId { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }
       public Patient Patient { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        [Required]
        [MaxLength(255)]
        public string Diagnosis { get; set; }

        [Required]
        [MaxLength(255)]
        public string Treatment { get; set; }

        [DataType(DataType.Date)]
        public DateTime DateOfVisit { get; set; } = DateTime.Now;
    }
}
