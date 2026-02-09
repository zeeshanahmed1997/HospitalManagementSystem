using System.Numerics;

namespace HospitalManagementSystem.Data.Models
{
    public class Department
    {
        public int Id { get; set; }
        public required string Name { get; set; } // e.g., Cardiology, OPD
        public string? Description { get; set; }
        public ICollection<Doctor>? Doctors { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
