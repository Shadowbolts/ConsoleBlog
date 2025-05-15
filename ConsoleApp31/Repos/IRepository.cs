namespace ConsoleApp31.Repos
{
    public interface IRepository<T> where T : class
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        T Add(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
