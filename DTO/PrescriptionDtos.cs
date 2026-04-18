namespace HospitalManagementSystem.DTO
{
    // PrescriptionDto.cs
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string? Instructions { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientEmail { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public List<PrescriptionItemDto> Items { get; set; } = new();
    }

    public class PrescriptionItemDto
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? Dosage { get; set; }
        public decimal? PriceAtIssue { get; set; }
    }

    public class CreatePrescriptionRequest
    {
        // Added PatientId because you are sending it from the frontend
        public int PatientId { get; set; }

        public DateTime PrescriptionDate { get; set; }

        // Match the frontend 'notes' or change frontend to 'instructions'
        // Let's stick to 'Instructions' but add a mapping or handle it
        public string? Instructions { get; set; }

        public List<CreatePrescriptionItemRequest> Items { get; set; } = new();
    }

    public class CreatePrescriptionItemRequest
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public string? Dosage { get; set; }
        // Added this because your frontend is sending an empty string for instructions in items
        public string? Instructions { get; set; }
    }
}
