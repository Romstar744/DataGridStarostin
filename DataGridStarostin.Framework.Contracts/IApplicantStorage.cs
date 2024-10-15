using DataGridStarostin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Framework.Contracts
{
	public interface IApplicantStorage
	{
		Task<IReadOnlyCollection<Applicant>> GetAllAsync();

		Task<Applicant> AddAsync(Applicant applicant);

		Task EditAsync(Applicant applicant);

		Task<bool> DeleteAsync(Guid id);
	}
}
