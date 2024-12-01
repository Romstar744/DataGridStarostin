using System.Diagnostics;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Contracts.Models;
using DataGridStarostin.WebApplication.Models;
using Microsoft.AspNetCore.Mvc;

namespace DataGridStarostin.WebApplication.Controllers
{
    /// <summary>
    /// ���������� ��� ���������� �������� ������������.
    /// </summary>
    public class ApplicantController : Controller
    {
        private readonly IApplicantManager applicantManager;

        /// <summary>
        /// ����������� �����������.
        /// </summary>
        public ApplicantController(IApplicantManager applicantManager)
        {
            this.applicantManager = applicantManager;
        }

        /// <summary>
        /// ���������� ������ ���� ������ ������������.
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
        /// ���������� ����� �������� ����� ������ �����������.
        /// </summary>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// ������������ �������� ����� ������ �����������.
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
        /// ���������� ����� �������������� ������ ����������� �� � ��������������.
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
        /// ������������ �������������� ������������ ������ �����������.
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
        /// ������������ �������� ������ ����������� �� � ��������������.
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
        /// ���������� �������� �������� ������������������.
        /// </summary>
        public IActionResult Privacy()
        {
            return View();
        }
    }
}
