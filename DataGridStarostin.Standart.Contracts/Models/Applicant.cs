using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataGridStarostin.Standart.Contracts.Models
{
    /// <summary>
    /// Класс для заполнения данных абитуриента
    /// </summary>
    public class Applicant
    {
        public Guid Id { get; set; }

        /// <summary>
        /// ФИО
        /// </summary>
        [DisplayName("Имя")]
        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Name { get; set; }

        /// <summary>
        /// <inheritdoc cref="DataGridStarostin.Models.Gender"/>
        /// </summary>
        [DisplayName("Пол")]
        [Required]
        public Gender Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        [DisplayName("Дата рождения")]
        [Required]
        public DateTime Birthday { get; set; }

        /// <summary>
        /// <inheritdoc cref="DataGridStarostin.Models.Education"/>
        /// </summary>
        [DisplayName("Форма обучения")]
        [Required]
        public Education Education { get; set; }

        /// <summary>
        /// Баллы по математике
        /// </summary>
        [DisplayName("Баллы по математике")]
        [Range(0, 100)]
        [Required]
        public double Math { get; set; }

        /// <summary>
        /// Баллы по русскому языку
        /// </summary>
        [DisplayName("Баллы по русскому")]
        [Range(0, 100)]
        [Required]
        public double Russian { get; set; }

        /// <summary>
        /// Баллы по информатике
        /// </summary>
        [DisplayName("Баллы по информатике")]
        [Range(0, 100)]
        [Required]
        public double ComputerScience { get; set; }
    }
}
