namespace HospitalManagementSystem.Data.Models
{
    public class Payment
    {
        public int Id { get; set; }
        public int BillId { get; set; }
        public Bill? Bill { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public string? PaymentMethod { get; set; }   // Cash, Card, Online, Insurance
        public string? TransactionId { get; set; }   // optional
        public string? Status { get; set; }          // Success, Pending, Refunded
    }
}
