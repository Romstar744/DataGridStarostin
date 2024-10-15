using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Models
{
    /// <summary>
    /// Пол
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
