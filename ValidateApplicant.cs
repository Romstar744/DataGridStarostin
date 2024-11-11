using System;
using System.ComponentModel.DataAnnotations;

namespace DataGridStarostin.Standart.Contracts.Models
{

    /// <summary>
    /// Класс для заполнения данных абитуриента
    /// </summary>
    public class ValidateApplicant
    {
        public Guid Id { get; set; }
        /// <summary>
        /// ФИО
        /// </summary>
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }
        /// <summary>
        /// <inheritdoc cref="DataGridStarostin.Models.Gender"/>
        /// </summary>
        [Required]
        public Gender Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        [Required]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// <inheritdoc cref="DataGridStarostin.Models.Education"/>
        /// </summary>
        [Required]
        public Education Education { get; set; }

        /// <summary>
        /// Баллы по математике
        /// </summary>
        [Range(0, 100)]
        [Required]
        public double Math { get; set; }

        /// <summary>
        /// Баллы по русскому языку
        /// </summary>
        [Range(0, 100)]
        [Required]
        public double Russian { get; set; }

        /// <summary>
        /// Баллы по информатике
        /// </summary>
        [Range(0, 100)]
        [Required]
        public double ComputerScience { get; set; }

        /// <summary>
        /// Сумма баллов за 3 экзамена ЕГЭ
        /// </summary>
    }
}
