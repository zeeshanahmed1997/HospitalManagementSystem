using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public required string Designation { get; set; } // Nurse, Receptionist, Pharmacist
        public decimal Salary { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public ApplicationUser? User { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
