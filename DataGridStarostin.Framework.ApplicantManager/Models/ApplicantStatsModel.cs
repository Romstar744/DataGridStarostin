using DataGridStarostin.Framework.Contracts;

namespace DataGridStarostin.Framework.ApplicantManager.Models
{
	public class ApplicantStatsModel : IApplicantStats
	{
		public int Count { get; set; }

		public int FemaleCount { get; set; }

		public int MaleCount { get; set; }

		public int FullTimeCount { get; set; }

		public int FTPTCount { get; set; }

		public double СorrespondenceCount { get; set; }

		public double MathCount { get; set;  }

		public double RussianCount { get; set; }

		public double ComputerScienceCount { get; set; }

		public double TotalScoreCount { get; set; }
	}
}
