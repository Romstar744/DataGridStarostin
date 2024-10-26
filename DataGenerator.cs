using System;
using DataGridStarostin.Standart.Contracts.Models;

namespace DataGridStarostin
{
    /// <summary>
    /// Помощник для генерации данных
    /// </summary>
    public static class DataGenerator
    {
        /// <summary>
        /// Сгенерировать <see cref="ValidateApplicant"/> по стандартным параметрам или по заданным
        /// </summary>
        public static ValidateApplicant CreateApplicant(Action<ValidateApplicant> settings = null)
        {
            var result = new ValidateApplicant
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
