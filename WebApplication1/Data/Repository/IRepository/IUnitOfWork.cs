namespace WebApplication1.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category{ get; }
        void Save();
    }
}
