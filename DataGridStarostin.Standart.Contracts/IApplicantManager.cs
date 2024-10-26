using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGridStarostin.Standart.Contracts.Models;

namespace DataGridStarostin.Standart.Contracts
{
    /// <summary>
    /// Интерфейс прослойки между <see cref="MemoryApplicantStorage"/> и представлением
    /// </summary>
    public interface IApplicantManager
    {
        /// <summary>
        /// Асинхронное получение всех данных
        /// </summary
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
        /// <summary>
        /// Асинхронная получение суммарных данных
        /// </summary>
        Task<IApplicantStats> GetStatsAsync();
    }
}
