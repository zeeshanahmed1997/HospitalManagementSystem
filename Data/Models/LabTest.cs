namespace HospitalManagementSystem.Data.Models
{
    public class LabTest
    {
        public int Id { get; set; }
        public required string TestName { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
