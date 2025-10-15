using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class Location
{
    [Key]
    public int LocationId { get; set; }

    [ForeignKey("Doctor")]
    public int DoctorId { get; set; }

    public string ClinicName { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Pincode { get; set; }

    // Navigation property
   // [JsonIgnore]
    //public Doctor Doctor { get; set; }
}