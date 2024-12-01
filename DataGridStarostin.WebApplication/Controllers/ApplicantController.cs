using System.Diagnostics;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Contracts.Models;
using DataGridStarostin.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataGridStarostin.WebApplication.Controllers
{
    /// <summary>
    /// Контроллер для управления заявками абитуриентов.
    /// </summary>
    public class ApplicantController : Controller
    {
        private readonly IApplicantManager applicantManager;

        /// <summary>
        /// Конструктор контроллера.
        /// </summary>
        public ApplicantController(IApplicantManager applicantManager)
        {
            this.applicantManager = applicantManager;
        }

        /// <summary>
        /// Отображает список всех заявок абитуриентов.
        /// </summary>
        public async Task<IActionResult> Index()
        {
            var applicants = applicantManager.GetAllAsync();
            var stats = applicantManager.GetStatsAsync();
            await Task.WhenAll(applicants, stats);

            ViewData[nameof(IApplicantStats)] = stats.Result;
            return View(applicants.Result);
        }

        /// <summary>
        /// Отображает форму создания новой заявки абитуриента.
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Обрабатывает создание новой заявки абитуриента.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Create(Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            applicant.Id = Guid.NewGuid();
            await applicantManager.AddAsync(applicant);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает форму редактирования заявки абитуриента по её идентификатору.
        /// </summary>
        public async Task<IActionResult> Edit(Guid id)
        {
            var applicants = await applicantManager.GetAllAsync();
            var applicant = applicants.FirstOrDefault(p => p.Id == id);
            if (applicant == null)
            {
                return NotFound();
            }

            return View(applicant);
        }

        /// <summary>
        /// Обрабатывает редактирование существующей заявки абитуриента.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Edit(Guid id, Applicant applicant)
        {
            if (!ModelState.IsValid)
            {
                return View(applicant);
            }

            var applicants = await applicantManager.GetAllAsync();
            var existingApplicant = applicants.FirstOrDefault(p => p.Id == id);
            if (existingApplicant == null)
            {
                return NotFound();
            }

            await applicantManager.EditAsync(applicant);
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Обрабатывает удаление заявки абитуриента по её идентификатору.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            var result = await applicantManager.DeleteAsync(id);
            if (result == false)
            {
                return NotFound();
            }
            return RedirectToAction(nameof(Index));
        }

        /// <summary>
        /// Отображает страницу политики конфиденциальности.
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
