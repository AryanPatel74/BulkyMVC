using BulkyRazorProject.Data;
using BulkyRazorProject.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BulkyRazorProject.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        [BindProperty]
        public Category categories { get; set; }
        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int?id)
        {
            categories =  _db.Categories.Find(id);
        }
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(categories);
                _db.SaveChanges();
                return RedirectToPage("Index");
            }
            return Page();

        }
    }
}
