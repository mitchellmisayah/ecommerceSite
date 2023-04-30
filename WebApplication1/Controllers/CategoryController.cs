using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;

        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = this.db.Categories.ToList(); //List<Category> objCategoryList = this.db.Categories.ToList();  they're the same
            return View(objCategoryList);
        }
        //Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if (obj.Name == obj.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Name", "The DisplayOrder cannot exactly match the Name.");
            }

            if (ModelState.IsValid)
            {
                this.db.Categories.Add(obj);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }

        //Edit

        public IActionResult Edit(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            
            Category? categoryFromDb = this.db.Categories.Find(id); //finds the primary key of Category and assigns it to categoryFromDb

            //Other ways that work
            //Category? categoryFromDb1 = this.db.Categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDb2 = this.db.Categories.Where(u=>u.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost]
        public IActionResult Edit(Category obj)
        {


            if (ModelState.IsValid)
            {
                this.db.Categories.Update(obj);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
