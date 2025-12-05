using ASP_PV411.Services.Random;

namespace ASP_PV411.Services.Rfn
{
    //Random File Name
    // 97–122 48–57 42 45 95
    public class RfnService(IRandomService randomService) : IRfnService
    {
        private readonly IRandomService _randomService = randomService;

        public string GetRfn(int? length = null)
        {
            length ??= 10;
            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length));
            }
            char[] chars = new char[length.Value];
            char[] allowedFileNameChars =
            {
                // Lowercase letters
                'a','b','c','d','e','f','g','h','i','j','k','l','m',
                'n','o','p','q','r','s','t','u','v','w','x','y','z',

                // Digits
                '0','1','2','3','4','5','6','7','8','9',

                // Safe special characters
                '!','#','$','%','&','\'','(',')','+',
                ',','-','.',';','=','@','[',']','^',
                '_','`','{','}','~'
            };
            for (int i = 0; i < length; i++)
            {
                chars[i] = allowedFileNameChars[_randomService.RandomInt() % allowedFileNameChars.Length];
            }
            return new string(chars);
        }
    }
}
