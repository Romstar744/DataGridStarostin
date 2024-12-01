using System.Diagnostics;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Contracts.Models;
using DataGridStarostin.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataGridStarostin.WebApplication.Controllers
{
    public class ApplicantController : Controller
    {
        private readonly IApplicantManager applicantManager;

        public ApplicantController(IApplicantManager applicantManager)
        {
            this.applicantManager = applicantManager;
        }

        /// <summary>
        /// Отображает список всех продуктов.
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
        /// Отображает страницу создания нового продукта.
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// Обрабатывает создание нового продукта.
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
        /// Отображает страницу редактирования продукта по его идентификатору.
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
        /// Обрабатывает редактирование существующего продукта.
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
        /// Обрабатывает удаление продукта по его идентификатору.
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
        /// Отображает страницу конфиденциальности.
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
