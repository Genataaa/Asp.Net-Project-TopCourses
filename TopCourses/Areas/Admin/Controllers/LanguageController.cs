﻿namespace TopCourses.Areas.Admin.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using TopCourses.Core.Contracts;
    using TopCourses.Core.Models.Language;

    public class LanguageController : BaseController
    {
        private readonly ILanguageService languageService;

        public LanguageController(ILanguageService languageService)
        {
            this.languageService = languageService;
        }

        public async Task<IActionResult> Index()
        {
            var languages = await languageService.GetAll();

            return View(languages);
        }

        public IActionResult Add()
        {
            var model = new LanguageViewModel();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(LanguageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await languageService.Add(model);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var model = await languageService.GetLanguageForEdit(id);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(LanguageViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            await languageService.Update(model);

            return RedirectToAction("Index", "Language");
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromForm] int id)
        {
            await languageService.Delete(id);

            return RedirectToAction("Index", "Language");
        }
    }
}