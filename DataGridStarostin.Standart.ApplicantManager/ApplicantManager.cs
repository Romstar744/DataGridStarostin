using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DataGridStarostin.Standart.ApplicantManager.Models;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Contracts.Models;
using Microsoft.Extensions.Logging;


namespace DataGridStarostin.Standart.ApplicantManager
{
    /// <inheritdoc cref="IApplicantManager"/>
    public class ApplicantManager : IApplicantManager
    {
        private readonly IApplicantStorage applicantStorage;
        private readonly ILogger logger;
        private const string StopwatchTemplate = "{0} выполнялся {1} мс";
        /// <summary>
        /// Конструктор
        /// </summary
        public ApplicantManager(IApplicantStorage applicantStorage, ILogger logger)
        {
            this.logger = logger;
            this.applicantStorage = applicantStorage;
        }
        /// <inheritdoc cref="IApplicantManager.AddAsync(Applicant)"/>
        public async Task<Applicant> AddAsync(Applicant applicant)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            var result = await applicantStorage.AddAsync(applicant);

            stopwatch.Stop();
            logger.LogInformation(string.Format(StopwatchTemplate, nameof(AddAsync), stopwatch.ElapsedMilliseconds));
            return result;
        }
        /// <inheritdoc cref="IApplicantManager.DeleteAsync(Guid)"/>
        public async Task<bool> DeleteAsync(Guid id)
        {
            var result = await applicantStorage.DeleteAsync(id);
            if (result)
            {
                logger.LogInformation($"Пользователь с идентификатором {id} удален");
            }
            else
            {
                logger.LogInformation($"Не уадлось удалить пользователя с идентификатром {id}");
            }
            return result;
        }
        /// <inheritdoc cref="IApplicantManager.EditAsync(Applicant)"/>
        public Task EditAsync(Applicant applicant)
            => applicantStorage.EditAsync(applicant);

        /// <inheritdoc cref="IApplicantManager.GetAllAsync()"/>
        public Task<IReadOnlyCollection<Applicant>> GetAllAsync()
            => applicantStorage.GetAllAsync();

        /// <inheritdoc cref="IApplicantManager.GetAllAsync()"/>
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
