namespace HospitalManagementSystem.Data.Models
{
    public class Prescription
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public Doctor Doctor { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string Instructions { get; set; } // general notes

        public ICollection<PrescriptionItem> Items { get; set; }
        public int? MedicalRecordId { get; set; } // optional link
    }
}
