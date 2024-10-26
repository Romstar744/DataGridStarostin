using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridStarostin.Standart.Contracts.Models;

namespace DataGridStarostin
{
    /// <summary>
    /// Методы приведения одного типа к другому
    /// </summary>
    public static class ValidateConverter
    {
        /// <summary>
        /// Привести <see cref="Applicant"/> к <see cref="ValidateApplicant"/>
        /// </summary>
        public static Applicant ToValidateApplicant(ValidateApplicant validateApplicant)
        {
            return new Applicant()
            {
                Id = validateApplicant.Id,
                Name = validateApplicant.Name,
                Gender = validateApplicant.Gender,
                Birthday = validateApplicant.Birthday,
                Education = validateApplicant.Education,
                Math = validateApplicant.Math,
                Russian = validateApplicant.Russian,
                ComputerScience = validateApplicant.ComputerScience,
            };
        }
        /// <summary>
        /// Привести <see cref="ValidateApplicant"/> к <see cref="Applicant"/>
        /// </summary>
        public static ValidateApplicant ToApplicant(Applicant applicant)
        {
            return new ValidateApplicant()
            {
                Id = applicant.Id,
                Name = applicant.Name,
                Gender = applicant.Gender,
                Birthday = applicant.Birthday,
                Education = applicant.Education,
                Math = applicant.Math,
                Russian = applicant.Russian,
                ComputerScience = applicant.ComputerScience,
            };
        }

    }
}
