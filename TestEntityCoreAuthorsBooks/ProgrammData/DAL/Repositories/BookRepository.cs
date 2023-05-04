using Microsoft.EntityFrameworkCore;
using TestEntityCoreAuthorsBooks.Data;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Repositories
{
    public class BookRepository : IRepository<Book>
    {
        private readonly ApplicationDbContext _context;

        public BookRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        Task<Book> IRepository<Book>.Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            _context.Books.Remove(_context.Books.Single(a => a.Id == id));
            _context.SaveChangesAsync();
            return Task.FromResult(true);
        }

        public async Task<int> Create(Book item)
        {
            await _context.Books.AddAsync(item);
            _context.Entry(item).State = EntityState.Added;
            await _context.SaveChangesAsync();

            int id = _context.Books.Entry(item).Entity.Id;

            return id;
        }

        Task<bool> IRepository<Book>.Update(Book item)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Book>> IRepository<Book>.GetAll()
        {
            return Task.FromResult((IEnumerable<Book>)_context.Books);
        }

        Task<IEnumerable<Book>> IRepository<Book>.Find(Author item)
        {
            throw new NotImplementedException();
        }
    }
}
