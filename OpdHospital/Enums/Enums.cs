namespace OpdHospital.Enums
{
    public enum HospitalType
    {
        Clinic = 1,
        Hospital = 2,
        Diagnostic = 3,
        Lab = 4
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
}
