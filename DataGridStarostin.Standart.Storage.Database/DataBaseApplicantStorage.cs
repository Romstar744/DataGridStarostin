using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using DataGridStarostin.Standart.Contracts;
using System.Data.Entity;
using DataGridStarostin.Standart.Contracts.Models;
using System.Linq;
using System.Xml.Linq;

namespace DataGridStarostin.Standart.Storage.Database
{
    public class DataBaseApplicantStorage : IApplicantStorage
    {
        public async Task<Applicant> AddAsync(Applicant applicant)
        {
            using (var context = new DataGridContext())
            {
                var person = new Applicant
                {
                    Id = applicant.Id,
                    Name = applicant.Name,
                    Birthday = applicant.Birthday,
                    Education = applicant.Education,
                    Math = applicant.Math,
                    Russian = applicant.Russian,
                    ComputerScience = applicant.ComputerScience,
                };
                context.Applicant.Add(applicant);
                await context.SaveChangesAsync();
            }

            return applicant;
        }
        public async Task<bool> DeleteAsync(Guid id)
        {
            using (var context = new DataGridContext())
            {
                var item = await context.Applicant.FirstOrDefaultAsync(x => x.Id == id);
                if (item != null)
                {
                    context.Applicant.Remove(item);
                    await context.SaveChangesAsync();
                    return true;
                }
            }

            return false;
        }
        public async Task EditAsync(Applicant applicant)
        {
            using (var context = new DataGridContext())
            {
                var target = await context.Applicant.FirstOrDefaultAsync(x => x.Id == applicant.Id);
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
                await context.SaveChangesAsync();
            }
        }
        public async Task<IReadOnlyCollection<Applicant>> GetAllAsync()
        {
            using (var context = new DataGridContext())
            {
                var items = await context.Applicant
                    .OrderBy(x => x.Name)
                    .ThenByDescending(x => x.Education)
                    .ToListAsync();

                return items.Select(x => new Applicant);
                {
                    Id = x.Id,
                    Name = x.Name,
                    Birthday = x.Birthday,
                    Education = x.Education,
                    Math = x.Math,
                    Russian = x.Russian,
                    ComputerScience = x.ComputerScience,
                }
            }
        }
    }
}
