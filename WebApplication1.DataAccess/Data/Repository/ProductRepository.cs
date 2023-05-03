using System.Linq.Expressions;
using WebApplication1.Data.Repository.IRepository;
using WebApplication1.DataAccess.Data;
using WebApplication1.Models;

namespace WebApplication1.Data.Repository
{
    
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }



        public void Update(Product obj)
        {
            _db.Products.Update(obj);
        }
    }
}
