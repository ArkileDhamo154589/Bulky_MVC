using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using WebRazon_Temp.Data;
using WebRazon_Temp.Models;

namespace WebRazon_Temp.Pages.Categories
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;

 
        [BindProperty]
        public Category Category { get; set; }


        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult OnGet(int id)
        {
           
            Category = _db.Categories.FirstOrDefault(c => c.Id == id);

            if (Category == null)
            {
                return NotFound();
            }

       
            return Page();
        }

        
        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
            
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["SuccessMessage"] = "Category updated successfully!";
                return RedirectToPage("/Categories/Index");
            }

          
            return Page();
        }
    }
}
