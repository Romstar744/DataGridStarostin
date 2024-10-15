using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridStarostin.Models;

namespace DataGridStarostin
{
    /// <summary>
    /// Помощник для генерации данных
    /// </summary>
    public static class DataGenerator
    {
        /// <summary>
        /// Сгенерировать <see cref="Applicant"/> по стандартным параметрам или по заданным
        /// </summary>
        public static Applicant CreateApplicant(Action<Applicant> settings = null)
        {
            var result = new Applicant
            {
                Id = Guid.NewGuid(),
                Name = Guid.NewGuid().ToString(),
                Birthday = DateTime.Now.AddYears(-16),
            };

            settings?.Invoke(result);
            return result;
        }
    }
}
