using BulkyBookWeb.Data;
using BulkyBookWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace BulkyBookWeb.Controllers
{
    public class CategoryController1 : Controller
    {

        private readonly ApplicationDbContext _db;
        public CategoryController1(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            IEnumerable<Category> objCategoryList = _db.Categories.ToList();
            return View(objCategoryList);
        }


        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == 0)
            {
                return NotFound();
            }

            var categoryFormDb = _db.Categories.Find(id);
            //var categoryFormDbFisrt = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFormDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);
           
            if(categoryFormDb == null)
            {

                return NotFound();
            }
            TempData["success"] = "Category edited success";
            return View(categoryFormDb);
        }
        //GET
        public IActionResult Create()
        {
            
            return View();
        }

        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {

            if (obj.Name == obj.DisplayOrde.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOreder cannot exactly match the Name.");
            }
            {

            }
            if (ModelState.IsValid)
            {

            _db.Categories.Add(obj);
            _db.SaveChanges();
            TempData["success"] = "Category created successfuly";
            return RedirectToAction("Index");
        }   return View(obj);
            }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {

            if (obj.Name == obj.DisplayOrde.ToString())
            {
                ModelState.AddModelError("name", "The DisplayOreder cannot exactly match the Name.");
            }
            {

            }
            if (ModelState.IsValid)
            {

                _db.Categories.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Category edited success";
                return RedirectToAction("Index");
            }
            return View(obj);
        }


        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePOST(int? id)
        {

            var obj = _db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }

            
            //var categoryFormDbFisrt = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFormDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);

            _db.Categories.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Category deleted successfuly";

            return  RedirectToAction("Index");
        }

        public IActionResult Delete (int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var categoryFormDb = _db.Categories.Find(id);
            //var categoryFormDbFisrt = _db.Categories.FirstOrDefault(u => u.Id == id);
            //var categoryFormDbSingle = _db.Categories.FirstOrDefault(u => u.Id == id);

            if (categoryFormDb == null)
            {

                return NotFound();
            }

            return View(categoryFormDb);
        }


    }
}

