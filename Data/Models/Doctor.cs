using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public required string Specialization { get; set; }
        public string? Qualification { get; set; }
        public decimal ConsultationFee { get; set; }

        public int DepartmentId { get; set; }
        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }
        public bool IsDeleted { get; set; } = false;
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
        public ICollection<MedicalRecord> MedicalRecords { get; set; } = new List<MedicalRecord>();
        public ICollection<Prescription> Prescriptions { get; set; } = new List<Prescription>();
    }
}
