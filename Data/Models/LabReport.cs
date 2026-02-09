using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.Models
{
    public class LabReport
    {
        public int Id { get; set; }
        public required string ResultDetails { get; set; }
        public DateTime TestDate { get; set; }
        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }
        public int LabTestId { get; set; }
        [ForeignKey("LabTestId")]
        public LabTest? LabTest { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
