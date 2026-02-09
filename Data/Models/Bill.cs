using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.Models
{
    public class Bill
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Tax { get; set; }
        public DateTime BillingDate { get; set; }
        public bool IsPaid { get; set; }
        public string? PaymentMethod { get; set; } // Cash, Card, Online

        public int AppointmentId { get; set; }
        [ForeignKey("AppointmentId")]
        public Appointment? Appointment { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
