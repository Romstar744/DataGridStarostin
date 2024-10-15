using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Models
{
    /// <summary>
    /// Варианты формы обучения
    /// </summary>
    public enum Education
    {
        /// <summary>
        /// Очная
        /// </summary>
        [Description("Очная")]
        FullTime = 1,

        /// <summary>
        /// Очно-заочная
        /// </summary>
		[Description("Очно-заочная")]
        FTPT = 2,

        /// <summary>
        /// Заочная
        /// </summary>
        [Description("Заочная")]
        Сorrespondence = 3,
    }
}
