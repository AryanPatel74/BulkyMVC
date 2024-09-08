using BulkyWeb.Data;
using BulkyWeb.Migrations;
using BulkyWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BulkyWeb.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationdbContextcs _db;
        public CategoryController(ApplicationdbContextcs db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            List<Category> data = new List<Category>();
            data = _db.Categories.ToList();
            return View(data);
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(obj.Name == obj.DisplayOrder)
            {
                ModelState.AddModelError("name", "Name and Display order should not be same");
            }
            if (ModelState.IsValid)
            {
                _db.Categories.Add(obj);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult Edit(int? id)
        {
            if(id==null || id == 0)
            {
                return NotFound();
            }
            Category? categoryDb = _db.Categories.Find(id);
            Category? categoryDb1 = _db.Categories.FirstOrDefault(u=>u.Id == id);
            Category? categoryDb2 = _db.Categories.Where(u=>u.Id==id).FirstOrDefault();
            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }
        [HttpPost]
        public IActionResult Edit(Category obj)
        {
            _db.Categories.Update(obj);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryDb = _db.Categories.Find(id);
            if (categoryDb == null)
            {
                return NotFound();
            }
            return View(categoryDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Category? categoryDb = _db.Categories.Find(id);
            if (categoryDb == null)
            {
                return NotFound();
            }
            _db.Categories.Remove(categoryDb);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
