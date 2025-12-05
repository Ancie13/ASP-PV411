namespace ASP_PV411.Services.OTP
{
    public interface IOtpService
    {
        String GetOtp(int? length = null);
    }
}
