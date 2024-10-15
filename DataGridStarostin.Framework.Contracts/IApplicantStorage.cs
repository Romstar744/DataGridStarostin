using DataGridStarostin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridStarostin.Framework.Contracts
{
    /// <summary>
    /// Интерфейс хранилища данных абитуриентов
    /// </summary>
    public interface IApplicantStorage
    {
        /// <summary>
        /// Асинхронное получение всех данных
        /// </summary>
        Task<IReadOnlyCollection<Applicant>> GetAllAsync();
        /// <summary>
        /// Асинхронная операция добавления
        /// </summary>
        Task<Applicant> AddAsync(Applicant applicant);
        /// <summary>
        /// Асинхронная операция изменения
        /// </summary>
        Task EditAsync(Applicant applicant);
        /// <summary>
        /// Асинхронная операция удаления
        /// </summary>
        Task<bool> DeleteAsync(Guid id);
    }
}
