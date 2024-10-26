
using DataGridStarostin.Standart.Contracts.Models;

namespace DataGridStarostin.Standart.ApplicantManager.Models
{
    /// <summary>
    /// Вычисляемые данные о списке <see cref="Applicant"/>
    /// </summary>
    public class ApplicantStatsModel : IApplicantStats
    {
        /// <inheritdoc cref="IApplicantStats.Count"/>
        public int Count { get; set; }
        /// <inheritdoc cref="IApplicantStats.FemaleCount"/>
        public int FemaleCount { get; set; }
        /// <inheritdoc cref="IApplicantStats.MaleCount"/>
        public int MaleCount { get; set; }
        /// <inheritdoc cref="IApplicantStats.FullTimeCount"/>
        public int FullTimeCount { get; set; }
        /// <inheritdoc cref="IApplicantStats.FTPTCount"/>
        public int FTPTCount { get; set; }
        /// <inheritdoc cref="IApplicantStats.СorrespondenceCount"/>
        public double СorrespondenceCount { get; set; }
        /// <inheritdoc cref="IApplicantStats.MathCount"/>
        public double MathCount { get; set; }
        /// <inheritdoc cref="IApplicantStats.RussianCount"/>
        public double RussianCount { get; set; }
        /// <inheritdoc cref="IApplicantStats.ComputerScienceCount"/>
        public double ComputerScienceCount { get; set; }
        /// <inheritdoc cref="IApplicantStats.TotalScoreCount"/>
        public double TotalScoreCount { get; set; }
    }
}
