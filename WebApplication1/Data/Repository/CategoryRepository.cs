using System.Linq.Expressions;
using WebApplication1.Data.Repository.IRepository;
using WebApplication1.Models;

namespace WebApplication1.Data.Repository
{
    
    public class CategoryRepository : Repository<Category>, ICategoryRepository 
    {
        private ApplicationDbContext _db;
        public CategoryRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Category obj)
        {
            _db.Categories.Update(obj);
        }
    }
}
