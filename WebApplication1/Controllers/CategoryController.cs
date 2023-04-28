using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;

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

        public IActionResult Create()
        {
            return View();
        }
    }
}
