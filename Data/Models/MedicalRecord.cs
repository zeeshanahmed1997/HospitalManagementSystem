using System.ComponentModel.DataAnnotations.Schema;
using System.Numerics;

namespace HospitalManagementSystem.Data.Models
{
    public class MedicalRecord
    {
        public int Id { get; set; }
        public required string Diagnosis { get; set; }
        public required string TreatmentPlan { get; set; }
        public required string Symptoms { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
