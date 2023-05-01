using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.Data.Repository.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository categoryRepo;
        

        public CategoryController(ICategoryRepository db)
        {
            this.categoryRepo = db;
        }
        public IActionResult Index()
        {
            var objCategoryList = this.categoryRepo.GetAll().ToList(); //List<Category> objCategoryList = this.db.Categories.ToList();  they're the same //test
            return View(objCategoryList);
        }

        //CRUD OPERATIONS ==============================

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
                this.categoryRepo.Add(obj);
                this.categoryRepo.Save();
                TempData["success"] = "Category created successfully";
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
            
            Category? categoryFromDb = this.categoryRepo.Get(u=>u.Id==id); //finds the primary key of Category and assigns it to categoryFromDb

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
                this.categoryRepo.Update(obj);
                this.categoryRepo.Save();
                TempData["success"] = "Category updated successfully";
                return RedirectToAction("Index");
            }

            return View();
        }

        //Delete

        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            Category? categoryFromDb = this.categoryRepo.Get(u => u.Id == id); //finds the primary key of Category and assigns it to categoryFromDb

            //Other ways that work
            //Category? categoryFromDb1 = this.db.Categories.FirstOrDefault(u=>u.Id == id);
            //Category? categoryFromDb2 = this.db.Categories.Where(u=>u.Id == id).FirstOrDefault();

            if (categoryFromDb == null)
            {
                return NotFound();
            }
            return View(categoryFromDb);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePOST(int? id)
        {
            //find category from database

            Category? obj = this.categoryRepo.Get(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            this.categoryRepo.Remove(obj);
            this.categoryRepo.Save();
            TempData["success"] = "Category deleted successfully";
            return RedirectToAction("Index");



        }


    }



}
