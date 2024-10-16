using System;
using System.Windows.Forms;
using DataGridStarostin.Framework.ApplicantManager;
using DataGridStarostin.Storage.Memory;

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
            var storage = new MemoryApplicantStorage();
            var manager = new ApplicantManager(storage);

            Application.Run(new Form1(manager));
        }
    }
}
