using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Models
{
    /// <summary>
    /// Абитуриент
    /// </summary>
    public class Applicant
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
        public Gender Gender { get; set; }

        /// <summary>
        /// День рождения
        /// </summary>
        public DateTime Birthday { get; set; }

        /// <summary>
        /// <inheritdoc cref="DataGridStarostin.Models.Education"/>
        /// </summary>
        [Range(0, 5)]
        public Education Education { get; set; }

        /// <summary>
        /// Средний балл Математика
        /// </summary>
        public decimal Math { get; set; }

        /// <summary>
        /// Средний балл Русский
        /// </summary>
        public decimal Russian { get; set; }

        /// <summary>
        /// Средний балл Информатика
        /// </summary>
        public decimal ComputerScience { get; set; }

        /// <summary>
        /// Сумма баллов за 3 экзамена
        /// </summary>
        public string TotalScore { get; set; }
    }
}
