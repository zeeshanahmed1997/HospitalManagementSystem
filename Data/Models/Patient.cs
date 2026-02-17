using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.Models
{
    public class Patient
    {
        public int Id { get; set; }
        public string? BloodGroup { get; set; }
        public string? EmergencyContact { get; set; }

        // Link to Identity User
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }

        public ICollection<Appointment>? Appointments { get; set; }
        public ICollection<MedicalRecord>? MedicalRecords { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<LabReport> LabReports { get; set; } = new List<LabReport>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
        public ICollection<Admission> Admissions { get; set; } = new List<Admission>();
    }
}
