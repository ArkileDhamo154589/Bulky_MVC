using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazon_Temp.Data;
using WebRazon_Temp.Models;

namespace WebRazon_Temp.Pages.Categories
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        [BindProperty]
        public Category Category { get; set; }

        public CreateModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {

                _db.Categories.Add(Category);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Category Created successfully!";
                return RedirectToPage("/Categories/Index");
            }

           
            return Page();
        }
    }
}
