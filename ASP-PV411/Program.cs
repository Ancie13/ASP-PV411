using ASP_PV411.Services.Hash;
using ASP_PV411.Services.Kdf;
using ASP_PV411.Services.OTP;
using ASP_PV411.Services.Random;
using ASP_PV411.Services.Rfn;
using ASP_PV411.Services.Salt;
using ASP_PV411.Services.Signature;
using ASP_PV411.Services.Timestamp;

namespace ASP_PV411
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddRandom();
            builder.Services.AddTimestamp();
            builder.Services.AddHash();
            builder.Services.AddSalt();
            builder.Services.AddKdf();
            builder.Services.AddSignature();
            builder.Services.AddOtp();
            builder.Services.AddRfn();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
