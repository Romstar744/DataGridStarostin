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
        private const string InfoLoggerTxt = "Действие {@applicant} c id {ID}, выполненно за {Milliseconds} мс";
        private const string ErrorLoggerTxt = "Действие {@applicant} c id {ID}, не было выполненно";

        /// <summary>
        /// Конструктор
        /// </summary>
        public ApplicantManager(IApplicantStorage applicantStorage, ILogger logger)
        {
            this.logger = logger;
            this.applicantStorage = applicantStorage;
        }
        /// <inheritdoc cref="IApplicantManager.AddAsync(Applicant)"/>
        async Task<Applicant> IApplicantManager.AddAsync(Applicant applicant)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            Applicant result;
            try
            {
                result = await applicantStorage.AddAsync(applicant);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                logger.LogInformation(
                    ErrorLoggerTxt,
                    nameof(IApplicantManager.AddAsync),
                    applicant.Id
                    );
                return null;
            }

            stopwatch.Stop();
            logger.LogInformation(
                InfoLoggerTxt,
                nameof(IApplicantManager.AddAsync),
                applicant.Id,
                stopwatch.ElapsedMilliseconds
                );
            return result;
        }
        /// <inheritdoc cref="IApplicantManager.DeleteAsync(Guid)"/>
        async Task<bool> IApplicantManager.DeleteAsync(Guid id)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            bool result;
            try
            {
                result = await applicantStorage.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                logger.LogInformation(ErrorLoggerTxt, nameof(IApplicantManager.DeleteAsync),
                         id
                         );
                return false;
            }

            stopwatch.Stop();
            logger.LogInformation(InfoLoggerTxt, nameof(IApplicantManager.DeleteAsync),
                    id,
                    stopwatch.ElapsedMilliseconds
                );
            return result;
        }
        /// <inheritdoc cref="IApplicantManager.EditAsync(Applicant)"/>
        async Task IApplicantManager.EditAsync(Applicant applicant)
        {
            var stopwatch = new Stopwatch();
            stopwatch.Start();

            try
            {
                await applicantStorage.EditAsync(applicant);
            }
            catch (Exception ex)
            {
                stopwatch.Stop();
                logger.LogInformation(ErrorLoggerTxt, nameof(IApplicantManager.EditAsync),
                         applicant.Id
                         );
            }

            stopwatch.Stop();
            logger.LogInformation(InfoLoggerTxt, nameof(IApplicantManager.EditAsync),
                    applicant.Id,
                    stopwatch.ElapsedMilliseconds
                );
        }

        /// <inheritdoc cref="IApplicantManager.GetAllAsync()"/>
        async Task<IReadOnlyCollection<Applicant>> IApplicantManager.GetAllAsync()
        {
            try
            {
                return await applicantStorage.GetAllAsync();
            }
            catch (Exception ex)
            {
                logger.LogInformation("Ошибка при получении абитуриентов");
            }
            return null;
        }

        /// <inheritdoc cref="IApplicantManager.GetStatsAsync()"/>
        async Task<IApplicantStats> IApplicantManager.GetStatsAsync()
        {
            try
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
                    TotalScoreCount = result.Where(x => x.Math + x.Russian + x.ComputerScience >= 150).Count(),
                };
            }
            catch (Exception ex)
            {
                logger.LogInformation("Ошибка при получении статистики");
            }
            return null;
        }
    }
}
