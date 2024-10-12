using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Models
{
    /// <summary>
    /// Форма обучения
    /// </summary>
    public enum Education
    {
        /// <summary>
        /// 
        /// </summary>
        [Description("Очный")]
        FullTime = 1,

        /// <summary>
        /// Женский
        /// </summary>
		[Description("Очно-заочный")]
        FTPT = 2,

        /// <summary>
        /// 
        /// </summary>
        [Description("Заочный")]
        Сorrespondence = 3,
    }
}
