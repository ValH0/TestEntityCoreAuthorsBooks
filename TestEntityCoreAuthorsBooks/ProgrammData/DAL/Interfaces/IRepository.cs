using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> Read(int id);
        Task<IEnumerable<Book>> Find(Author item);
        Task<int> Create(T item);
        Task<bool> Update(T item);
        Task<bool> Remove(int id);
    }
}
