using WebApplication1.Data.Repository.IRepository;
using WebApplication1.DataAccess.Data;

namespace WebApplication1.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
        }




        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
