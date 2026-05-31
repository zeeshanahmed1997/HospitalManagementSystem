namespace HospitalManagementSystem.DTO
{
    // PrescriptionDto.cs
    public class PrescriptionDto
    {
        public int Id { get; set; }
        public DateTime PrescriptionDate { get; set; }
        public string? Instructions { get; set; }
        public int PatientId { get; set; }
        public string PatientName { get; set; } = string.Empty;
        public string PatientEmail { get; set; } = string.Empty;
        public int DoctorId { get; set; }
        public string DoctorName { get; set; } = string.Empty;
        public List<PrescriptionItemDto> Items { get; set; } = new();
    }

    public class PrescriptionItemDto
    {
        public int Id { get; set; }
        public int MedicineId { get; set; }
        public string MedicineName { get; set; } = string.Empty;
        public int Quantity { get; set; }
        public string? Dosage { get; set; }
        public decimal? PriceAtIssue { get; set; }
    }

    public class CreatePrescriptionRequest
    {
        // Added PatientId because you are sending it from the frontend
        public int PatientId { get; set; }

        public DateTime PrescriptionDate { get; set; }

        // Match the frontend 'notes' or change frontend to 'instructions'
        // Let's stick to 'Instructions' but add a mapping or handle it
        public string? Instructions { get; set; }

        public List<CreatePrescriptionItemRequest> Items { get; set; } = new();
    }

    public class CreatePrescriptionItemRequest
    {
        public int MedicineId { get; set; }
        public int Quantity { get; set; }
        public string? Dosage { get; set; }
        // Added this because your frontend is sending an empty string for instructions in items
        public string? Instructions { get; set; }
    }
    public class BillDto
    {
        public int Id { get; set; }
        public decimal TotalAmount { get; set; }
        public decimal Tax { get; set; }
        public DateTime BillingDate { get; set; }
        public bool IsPaid { get; set; }
        public string? PaymentMethod { get; set; }
        public int? AppointmentId { get; set; }
    }

    public class AdminReportDto
    {
        // Appointment stats
        public int TotalAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
        public int ConfirmedAppointments { get; set; }

        // Revenue
        public decimal TotalRevenue { get; set; }
        public decimal PaidRevenue { get; set; }
        public decimal UnpaidRevenue { get; set; }
        public List<RevenueByMonthDto> RevenueByMonth { get; set; } = new();

        // Prescriptions
        public int TotalPrescriptions { get; set; }
        public int TotalMedicinesDispensed { get; set; }

        // Doctor performance
        public List<DoctorPerformanceDto> DoctorPerformance { get; set; } = new();

        // Patient visits
        public int TotalPatients { get; set; }
        public int UniquePatients { get; set; }
        public List<PatientVisitDto> RecentPatientVisits { get; set; } = new();
    }

    public class DoctorReportDto
    {
        // Appointment stats
        public int TotalAppointments { get; set; }
        public int PendingAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int CancelledAppointments { get; set; }
        public int ConfirmedAppointments { get; set; }

        // Prescriptions
        public int TotalPrescriptions { get; set; }
        public int TotalMedicinesDispensed { get; set; }

        // Patient visits
        public int UniquePatients { get; set; }
        public List<PatientVisitDto> RecentPatientVisits { get; set; } = new();

        // Appointment trend by month
        public List<RevenueByMonthDto> AppointmentsByMonth { get; set; } = new();
    }

    public class RevenueByMonthDto
    {
        public string Month { get; set; } = string.Empty;  // "Jan 2026"
        public decimal Amount { get; set; }
        public int Count { get; set; }
    }

    public class DoctorPerformanceDto
    {
        public string DoctorName { get; set; } = string.Empty;
        public int TotalAppointments { get; set; }
        public int CompletedAppointments { get; set; }
        public int TotalPrescriptions { get; set; }
    }

    public class PatientVisitDto
    {
        public string PatientName { get; set; } = string.Empty;
        public string? PatientEmail { get; set; }
        public DateTime LastVisit { get; set; }
        public int TotalVisits { get; set; }
    }
}
