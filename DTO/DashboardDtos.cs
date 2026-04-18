namespace HospitalManagementSystem.DTO
{
    public class DashboardStatsResponse
    {
        public bool Success { get; set; } = true;
        public string? Message { get; set; }

        public int TotalPatients { get; set; }
        public int ActiveDoctors { get; set; }
        public decimal Revenue { get; set; }
        public decimal PendingBills { get; set; }

        // Optional helpers for frontend
        public string RevenueFormatted => $"₹{Revenue / 1000000:F1}M";
        public string PendingBillsFormatted => $"₹{PendingBills:N0}";
    }
}
