using ASP_PV411.Services.Random;

namespace ASP_PV411.Services.OTP
{
    public class RandomOtpService(IRandomService randomService) : IOtpService
    {
        private readonly IRandomService _randomService = randomService;

        public string GetOtp(int? length = null)
        {
            length ??= 6;
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            char[] chars = new char[length.Value];
            for (int i = 0; i < length; i++)
            {
                chars[i] = (char)(48 + _randomService.RandomInt() % 10);
            }
            return new string(chars);
        }
    }
}
