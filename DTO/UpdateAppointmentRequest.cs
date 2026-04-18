namespace HospitalManagementSystem.DTO
{
    public class UpdateAppointmentRequest
    {
        public DateTime? AppointmentDate { get; set; }
        public string? Reason { get; set; }
        public int? Status { get; set; }
    }
}
