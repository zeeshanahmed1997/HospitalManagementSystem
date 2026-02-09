namespace HospitalManagementSystem.Data.Models
{
    public class Medicine
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        //public required string Manufacturer { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public DateTime ExpiryDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
