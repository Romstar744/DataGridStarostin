using DataGridStarostin.Framework.Contracts;
using DataGridStarostin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Storage.Memory
{
    public class MemoryApplicantStorage : IApplicantStorage
    {
        private List<Applicant> people;

        public MemoryApplicantStorage()
        {
            people = new List<Applicant>();
        }

        public Task<Applicant> AddAsync(Applicant applicant)
        {
            people.Add(applicant);
            return Task.FromResult(applicant);
        }

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

        public Task EditAsync(Applicant applicant) 
        {
            var target = people.FirstOrDefault(x => x.Id == applicant.Id);
            if (applicant != null) 
            {
				target.Name = applicant.Name;
				target.Gender = applicant.Gender;
				target.Birthday = applicant.Birthday;
				target.Education = applicant.Education;
				target.Math = applicant.Math;
				target.Russian = applicant.Russian;
				target.ComputerScience = applicant.ComputerScience;
				target.TotalScore = applicant.TotalScore;
			}

            return Task.CompletedTask;
        }

        public Task<IReadOnlyCollection<Applicant>> GetAllAsync()
            => Task.FromResult<IReadOnlyCollection<Applicant>>(people);
    }
}
