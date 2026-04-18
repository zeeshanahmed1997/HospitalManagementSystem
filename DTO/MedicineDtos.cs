namespace HospitalManagementSystem.DTO
{
    // MedicineDto.cs
    public class MedicineDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string? GenericName { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int StockQuantity { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool IsAvailable => StockQuantity > 0;
    }

    // CreateMedicineRequest.cs
    public class CreateMedicineRequest
    {
        public string Name { get; set; } = string.Empty;
        public string? GenericName { get; set; }
        public string? Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int InitialStock { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    // UpdateMedicineRequest.cs
    public class UpdateMedicineRequest
    {
        public string? Name { get; set; }
        public string? GenericName { get; set; }
        public string? Description { get; set; }
        public decimal? UnitPrice { get; set; }
        public DateTime? ExpiryDate { get; set; }
    }

    // StockUpdateRequest.cs  (for adding/reducing stock)
    public class StockUpdateRequest
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }        // Positive = Add, Negative = Reduce
        public string? Reason { get; set; }      // e.g., "Purchase", "Prescription Issued", "Expired"
    }
}
