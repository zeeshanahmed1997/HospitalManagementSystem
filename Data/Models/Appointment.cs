using HospitalManagementSystem.Data.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.Models
{
    public class Appointment
    {
        public int Id { get; set; }
        public DateTime AppointmentDate { get; set; }
        public string? Reason { get; set; }
        public AppointmentStatus Status { get; set; } // Enum: Pending, Confirmed, Cancelled

        public int PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient? Patient { get; set; }

        public int DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor? Doctor { get; set; }
            public bool IsDeleted { get; set; } = false;
    }
}
