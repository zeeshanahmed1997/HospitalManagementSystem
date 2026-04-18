namespace HospitalManagementSystem.DTO
{
    public class AppointmentDto
    {
    public DateTime? AppointmentDate { get; set; }
        public int Id { get; set; }
        public string? Reason { get; set; }
        public string? Status { get; set; }
        public int PatientId { get; set; }
        public string? PatientName { get; set; }
        public string? PatientEmail { get; set; }
        public string? PatientPhone { get; set; }
        public int DoctorId { get; set; }
        public string? DoctorName { get; set; }
    }
}
