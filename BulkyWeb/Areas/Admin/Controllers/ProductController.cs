
using Bulky.DataAccess.Data.Repository;
using Bulky.DataAccess.Data.Repository.IRepository;
using Bulky.DataAcess.Data;
using Bulky.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BulkyWeb.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            List<Product> objProductList = _unitOfWork.Product.GetAll().ToList();
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category
                .GetAll().Select(u => new SelectListItem
                {
                    Text = u.Name,
                    Value = u.Id.ToString()
                });

            return View(objProductList);
        }
        public IActionResult Create()
        {
            IEnumerable<SelectListItem> CategoryList = _unitOfWork.Category
             .GetAll().Select(u => new SelectListItem
             {
                 Text = u.Name,
                 Value = u.Id.ToString()
             });

            //ViewBag.CategoryList = CategoryList;
            ViewData["CategoryList"] = CategoryList;
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product obj)
        {
          
            if (ModelState.IsValid)
            {
                _unitOfWork.Product.Add(obj);
                _unitOfWork.save();
                TempData["succes"] = "Product created succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost]
        public IActionResult Edit(Product obj)
        {

            if (ModelState.IsValid)
            {
                _unitOfWork.Product.update(obj);
                _unitOfWork.save();
                TempData["succes"] = "Product updated succesfully";
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            Product? productFromDb = _unitOfWork.Product.Get(u => u.Id == id);

            if (productFromDb == null)
            {
                return NotFound();
            }
            return View(productFromDb);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Product obj = _unitOfWork.Product.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }

            _unitOfWork.Product.Remove(obj);
            _unitOfWork.save();
            TempData["succes"] = "Product deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
