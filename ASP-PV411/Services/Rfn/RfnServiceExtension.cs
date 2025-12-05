using ASP_PV411.Services.Salt;

namespace ASP_PV411.Services.Rfn
{
    public static class RfnServiceExtension
    {
        public static void AddRfn(this IServiceCollection services)
        {
            services.AddSingleton<IRfnService, RfnService>();
        }
    }
}
