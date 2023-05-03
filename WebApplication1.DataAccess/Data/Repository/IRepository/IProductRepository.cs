using WebApplication1.Models;

namespace WebApplication1.Data.Repository.IRepository
{
    public interface IProductRepository : IRepository<Product>
    {

        void Update(Product obj);

    }
}
