namespace E_Commerce_API.Repositories
{
    public interface IRepository<T> where T : class
    {


        Task<IEnumerable<T>> GetAllAsync();
        Task<T?> GetByIdAsync(int id);
        Task AddAsync(T entity);
        void DeleteAsync(T entity);
        void Update(T entity);
        Task<bool> SaveChangesAsync();

    }
}
