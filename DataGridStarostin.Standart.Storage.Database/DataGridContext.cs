using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using DataGridStarostin.Standart.Contracts.Models;

namespace DataGridStarostin.Standart.Storage.Database
{
    public class DataGridContext : DbContext
    {
        public DataGridContext()
            : base("DataGridConnectionString")
        {
        }

        public DbSet<Applicant> Applicant { get; set; }

        // public DbSet<ClassRoom> ClassRoom { get; set; }
    }
}
