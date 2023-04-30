﻿using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category obj)
        {
            if(ModelState.IsValid)
            {
                this.db.Categories.Add(obj);
                this.db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View();
        }
    }
}
