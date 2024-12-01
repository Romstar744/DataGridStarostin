using DataGridStarostin.Standart.ApplicantManager;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Storage.DB;
using Serilog;

namespace DataGridStarostin.WebApplication
{
    /// <summary>
    /// Главный класс приложения, отвечающий за запуск и конфигурацию.
    /// </summary>
    public static class Program
    {
        /// <summary>
        /// Главная функция приложения.
        /// </summary>
        public static void Main(string[] args)
        {
            Log.Logger = new LoggerConfiguration()
               .WriteTo.Seq("http://localhost:5341")
               .CreateLogger();

            var builder = Microsoft.AspNetCore.Builder.WebApplication.CreateBuilder(args);
            builder.Services.AddControllersWithViews();

            builder.Services.AddSingleton<IApplicantStorage, DataBaseApplicantStorage>();
            builder.Services.AddScoped<IApplicantManager, ApplicantManager>();
            builder.Services.AddLogging(loggingBuilder => loggingBuilder.AddSerilog(dispose: true));

            var app = builder.Build();

            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();

            app.MapControllerRoute(
                "default",
                "{controller=Applicant}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
