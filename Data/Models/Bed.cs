using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Data.Models
{
    public class Bed
    {
        public int Id { get; set; }
        public string? BedNumber { get; set; }
        public bool IsOccupied { get; set; }
        public int WardId { get; set; }
        [ForeignKey("WardId")]
        public Ward? Ward { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
