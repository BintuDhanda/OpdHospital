namespace OpdHospital.Dtos
{
    public class ResetPasswordRequestDto
    {
        public string UserName { get; set; }
        public string Otp {  get; set; }
        public string NewPassword { get; set; }
    }
}
