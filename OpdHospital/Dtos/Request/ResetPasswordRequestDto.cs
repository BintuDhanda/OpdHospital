namespace OpdHospital.Dtos
{
    public class ResetPasswordRequestDto
    {
        public string Identifier { get; set; }
        public string Otp {  get; set; }
        public string NewPassword { get; set; }
    }
}
