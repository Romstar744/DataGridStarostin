using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridStarostin.Models;

namespace DataGridStarostin
{
    internal class DataGenerator
    {
        public static Applicant CreateApplicant(Action<Applicant> settings = null)
        {
            var result = new Applicant
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Birthday = DateTime.Now.AddDays(-16),
            };

            settings?.Invoke(result);
            return result;
        }
    }
}
