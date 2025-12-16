namespace OpdHospital.Enums
{
    public enum HospitalType
    {
        Clinic = 1,
        Hospital = 2,
        Diagnostic = 3,
        Lab = 4
    }

    public enum AppointmentStatus
    {
        Scheduled = 1,
        Completed = 2,
        Cancelled = 3,
        NoShow = 4,
        Rescheduled = 5
    }

    public enum HospitalStatus
    {
        Draft = 1,
        Submitted = 2,
        Approved = 3,
        Active = 4,
        Suspended = 5
    }

    public enum PayoutCycle
    {
        Weekly = 1,
        Monthly = 2
    }

    public enum PayoutStatus
    {
        Enabled = 1,
        OnHold = 2
    }

    public enum Gender
    {
       Male = 1,
       Female = 2,
       Other = 3,
    }

    public enum SpecializationType
    {
        General = 1,
        Specialist = 2,
        Consultant = 3,
        Surgeon = 4,
        Therapist = 5,
        Pediatrician = 6,
        Cardiologist = 7,
        Dermatologist = 8,
        Neurologist = 9,
        Psychiatrist = 10
    }

    public enum AppointmentType
    {
        FixedTime = 1,
        AnyTime = 2,
        PackageVisit = 3
    }

     public enum PaymentStatus
    {
        Pending = 0,          // Payment initiated but not completed
        Success = 1,          // Payment completed successfully
        Failed = 2,           // Payment failed at gateway
        Cancelled = 3,        // User cancelled payment
        PartiallyRefunded = 4,// Partial refund processed
        Refunded = 5          // Full refund processed
    }

    public enum RefundStatus
    {
        Pending = 0,          // Refund initiated but not completed
        Processing = 1,       // Refund request accepted by gateway
        Success = 2,          // Refund completed successfully
        Failed = 3,           // Refund failed
        Cancelled = 4         // Refund cancelled / reversed
    }

}
