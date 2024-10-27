using System.ComponentModel;

namespace DataGridStarostin.Standart.Contracts.Models
{
    /// <summary>
    /// Варианты гендерного обозначения (пол)
    /// </summary>
    public enum Gender
    {
        /// <summary>
        /// Мужской
        /// </summary>
        [Description("Мужской")]
        Male = 1,

        /// <summary>
        /// Женский
        /// </summary>
		[Description("Женский")]
        Female = 2,
    }
}
