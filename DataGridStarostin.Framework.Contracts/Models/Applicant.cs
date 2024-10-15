using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Models
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
        [Range(0, 300)]
        [Required]
        public double TotalScore { get; set; }
    }
}
