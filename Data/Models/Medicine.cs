using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.Models
{
    public class Medicine
    {
        public int Id { get; set; }

        [Required]
        [StringLength(150)]
        public required string Name { get; set; }

        [StringLength(150)]
        public string? GenericName { get; set; }

        [StringLength(500)]
        public string? Description { get; set; }

        // Uncomment if you need manufacturer later
        // [StringLength(100)]
        // public string? Manufacturer { get; set; }

        [Precision(18, 2)]
        public decimal UnitPrice { get; set; }

        public int StockQuantity { get; set; } = 0;

        public DateTime ExpiryDate { get; set; }

        public bool IsDeleted { get; set; } = false;

        // Optional: Helpful computed properties (not mapped to DB)
        [NotMapped]
        public bool IsLowStock => StockQuantity < 20;

        [NotMapped]
        public bool IsExpired => ExpiryDate < DateTime.UtcNow;

        [NotMapped]
        public bool IsAvailable => StockQuantity > 0 && !IsExpired;
    }
}