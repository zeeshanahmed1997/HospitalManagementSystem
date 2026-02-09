namespace HospitalManagementSystem.Data.Models
{
    public class Ward
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Type { get; set; } // General, ICU, Private
        public int TotalBeds { get; set; }
        public ICollection<Bed>? Beds { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
