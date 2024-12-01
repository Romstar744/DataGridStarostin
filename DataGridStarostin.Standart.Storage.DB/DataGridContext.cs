using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DataGridStarostin.Standart.Contracts.Models;

namespace DataGridStarostin.Standart.Storage.DB
{
    /// <summary>
    /// Контекст базы данных
    /// </summary>
    public class DataGridContext : DbContext
    {
        /// <summary>
        /// Конструктор контекста базы данных
        /// </summary>
        public DataGridContext() : base("DataGridApplicants")
        {
        }

        /// <summary>
        /// Таблица <see cref="Applicant"/> в базе данных
        /// </summary>
        public DbSet<Applicant> Applicant { get; set; }
    }
}
