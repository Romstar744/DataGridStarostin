using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Framework.Contracts
{
    public interface IApplicantStats
    {
		int Count { get; }

		int FemaleCount { get; }

		int MaleCount { get; }

		int FullTimeCount { get; }

		int FTPTCount { get; }

		double СorrespondenceCount { get; }

		double MathCount { get; }

		double RussianCount { get; }

		double ComputerScienceCount { get; }

		double TotalScoreCount { get; }
	}
}
