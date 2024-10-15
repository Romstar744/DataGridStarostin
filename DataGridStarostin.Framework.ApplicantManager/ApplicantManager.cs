using DataGridStarostin.Framework.ApplicantManager.Models;
using DataGridStarostin.Framework.Contracts;
using DataGridStarostin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Framework.ApplicantManager
{
	public class ApplicantManager : IApplicantManager
	{
		private IApplicantStorage applicantStorage;

		public ApplicantManager(IApplicantStorage applicantStorage)
		{
			this.applicantStorage = applicantStorage;
		}

		public async Task<Applicant> AddAsync(Applicant applicant)
		{
			var result = await applicantStorage.AddAsync(applicant);
			return result;
		}

		public async Task<bool> DeleteAsync(Guid id)
		{
			var result = await applicantStorage.DeleteAsync(id);
			return result;
		}

		public Task EditAsync(Applicant applicant)
			=> applicantStorage.EditAsync(applicant);

		public Task<IReadOnlyCollection<Applicant>> GetAllAsync()
			=> applicantStorage.GetAllAsync();

		public async Task<IApplicantStats> GetStatsAsync()
		{
			var result = await applicantStorage.GetAllAsync();
			return new ApplicantStatsModel
			{
				Count = result.Count,
				MaleCount = result.Where(x => x.Gender == Gender.Male).Count(),
				FemaleCount = result.Where(x => x.Gender == Gender.Female).Count(),
				FullTimeCount = result.Where(x => x.Education == Education.FullTime).Count(),
				FTPTCount = result.Where(x => x.Education == Education.FTPT).Count(),
				СorrespondenceCount = result.Where(x => x.Education == Education.Сorrespondence).Count(),
				TotalScoreCount = result.Where(x => x.TotalScore >= 150).Count(),
			};
		}
	}
}
