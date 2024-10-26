using System;
using System.Windows.Forms;
using DataGridStarostin.Standart.ApplicantManager;
using DataGridStarostin.Standart.Storage.Memory;
using Microsoft.Extensions.Logging;

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

            var factory = LoggerFactory.Create(builder => builder.AddDebug());
            var logger = factory.CreateLogger(nameof(DataGrid));

            var storage = new MemoryApplicantStorage();
            var manager = new ApplicantManager(storage, logger);

            Application.Run(new Form1(manager));
        }
    }
}
