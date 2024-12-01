using System;
using System.Windows.Forms;
using DataGridStarostin.Standart.ApplicantManager;
using DataGridStarostin.Standart.Storage.Memory;
using Microsoft.Extensions.Logging;
using DataGridStarostin.Standart.Storage.DB;
using Serilog;
using Serilog.Extensions.Logging;
using DataGridStarostin.Standart.Contracts;

namespace DataGridStarostin
{
    internal static class Program
    {

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var serilogLogger = new LoggerConfiguration()
            .MinimumLevel.Verbose()
            .WriteTo.Seq("http://localhost:5341")
            .CreateLogger();

            var logger = new SerilogLoggerFactory(serilogLogger).CreateLogger<IApplicantManager>();

            var storage = new DataBaseApplicantStorage();
            var manager = new ApplicantManager(storage, logger);

            Application.Run(new Form1(manager));
        }
    }
}
