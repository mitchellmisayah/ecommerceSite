using WebApplication1.Models;

namespace WebApplication1.Data.Repository.IRepository
{
    public interface ICategoryRepository : IRepository<Category>
    {

        void Update(Category obj);
        void Save();
    }
}
