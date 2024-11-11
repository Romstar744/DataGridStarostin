using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Contracts.Models;

namespace DataGridStarostin.Standart.Storage.Memory
{
    /// <inheritdoc cref="IApplicantStorage"/>
    public class MemoryApplicantStorage : IApplicantStorage
    {
        private List<Applicant> people;

        /// <summary>
        /// Конструктор
        /// </summary>
        public MemoryApplicantStorage()
        {
            people = new List<Applicant>();
        }
        /// <summary>
        /// Асинхронный метод добавления абитуриента
        /// </summary>
        public Task<Applicant> AddAsync(Applicant applicant)
        {
            people.Add(applicant);
            return Task.FromResult(applicant);
        }

        /// <summary>
        /// Асинхронный метод удаления абитуриента
        /// </summary>
        public Task<bool> DeleteAsync(Guid id)
        {
            var applicant = people.FirstOrDefault(x => x.Id == id);
            if (applicant != null)
            {
                people.Remove(applicant);
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        /// <summary>
        /// Асинхронный метод редактирования абитуриента
        /// </summary>
        public Task EditAsync(Applicant applicant)
        {
            var target = people.FirstOrDefault(x => x.Id == applicant.Id);
            if (target != null)
            {
                target.Name = applicant.Name;
                target.Gender = applicant.Gender;
                target.Birthday = applicant.Birthday;
                target.Education = applicant.Education;
                target.Math = applicant.Math;
                target.Russian = applicant.Russian;
                target.ComputerScience = applicant.ComputerScience;
            }

            return Task.CompletedTask;
        }

        /// <summary>
        /// Получение абитуриентов из хранилища
        /// </summary>
        public Task<IReadOnlyCollection<Applicant>> GetAllAsync()
            => Task.FromResult<IReadOnlyCollection<Applicant>>(people);
    }
}
