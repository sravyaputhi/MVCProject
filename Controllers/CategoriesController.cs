using Microsoft.AspNetCore.Mvc;
using MVCCourse.Models;
using System.Reflection.Metadata.Ecma335;

namespace MVCCourse.Controllers
{
    public class CategoriesController : Controller
    {
        public IActionResult Index()
        {
            var categories=CategoriesRepository.GetCategories();
            return View(categories);
        }

        public IActionResult Edit([FromRoute]int? id)//can use FromQuery also
        {
            ViewBag.Action = "edit";
            //var category = new Category { CategoryId =id.HasValue ? id.Value : 0 };
            var category = CategoriesRepository.GetCategoryById(id.HasValue ? id.Value : 0);
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.UpdateCategory(category.CategoryId, category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Add() {
            ViewBag.Action = "add";
            return View(); 
        }

        [HttpPost]
        public IActionResult Add([FromForm] Category category)
        {
            if (ModelState.IsValid)
            {
                CategoriesRepository.AddCategory(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            CategoriesRepository.DeleteCategory(id);
            return RedirectToAction(nameof(Index));
        }
    
    }
}
