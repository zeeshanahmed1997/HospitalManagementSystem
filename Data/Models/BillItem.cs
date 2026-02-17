namespace HospitalManagementSystem.Data.Models
{
    public class BillItem
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public Bill? Bill { get; set; }
        public string? Description { get; set; }     // "Consultation", "Amoxicillin 500mg", "CBC Test", etc.
        public decimal Amount { get; set; }
        public string? ItemType { get; set; }        // Enum: Consultation, Medicine, Lab, Ward, Other
        public int? ReferenceId { get; set; }       // e.g. AppointmentId, PrescriptionItemId, LabReportId
        public bool IsDeleted { get; set; } = false;
    }
}
