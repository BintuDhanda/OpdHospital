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
}
