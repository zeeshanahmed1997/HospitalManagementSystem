namespace HospitalManagementSystem.Data.Models
{
    public class Admission
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient? Patient { get; set; }
        public int? BedId { get; set; }
        public Bed Bed { get; set; }
        public DateTime AdmissionDate { get; set; }
        public DateTime? DischargeDate { get; set; }
        public string? Reason { get; set; }
        public string? DiagnosisAtAdmission { get; set; }
        public int? DoctorId { get; set; } // admitting doctor
        public bool IsDeleted { get; set; } = false;
    }
}
