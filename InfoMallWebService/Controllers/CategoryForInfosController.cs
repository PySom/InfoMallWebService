using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using InfoMallWebService.Repository;
using InfoMallWebService.Models;

namespace InfoMallWebService.Controllers
{
    public class CategoryForInfosController : Controller
    {
        private readonly ICategoryForInfoRepository _cat;
        public CategoryForInfosController(ICategoryForInfoRepository category)
        {
            _cat = category;
        }
        // GET: CategoryForInfos
        public async Task<IActionResult> Index()
        {
            var model = await _cat.GetAllCategories(false);
            return View(model);
        }

        // GET: CategoryForInfos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var model = await _cat.GetCategoryById(id, true);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // GET: ContentsForInfos/Mall
        public async Task<IActionResult> Mall()
        {
            var model = await _cat.GetAllCategories(true);
            return View(model);
        }

        // GET: CategoryForInfos/Create
        public IActionResult Create()
        {

            return View();
        }

        // POST: CategoryForInfos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryForInformation category)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                await _cat.AddCategory(category);
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: CategoryForInfos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var model = await _cat.GetCategoryById(id, false);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: CategoryForInfos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, CategoryForInformation category)
        {
            if (id != category.CategoryId)
            {
                return RedirectToAction("Error", "Home");
            }
            if(!ModelState.IsValid)
            {
                return View("Edit", new { id });
            }
            try
            {
                await _cat.UpdateCategoryById(category);

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }

        // GET: CategoryForInfos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var model = await _cat.GetCategoryById(id, false);
            if (model == null)
            {
                return NotFound();
            }
            return View(model);
        }

        // POST: CategoryForInfos/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                _cat.DeleteCategoryById(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction("Error", "Home");
            }
        }
    }
}