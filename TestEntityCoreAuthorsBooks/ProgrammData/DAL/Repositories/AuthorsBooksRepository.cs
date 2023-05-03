using Microsoft.EntityFrameworkCore;
using TestEntityCoreAuthorsBooks.Data;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Repositories
{
    public class AuthorsBooksRepository : IRepository<AuthorsBooks>
    {
        private readonly ApplicationDbContext _context;

        public AuthorsBooksRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<AuthorsBooks> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Create(AuthorsBooks item)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == item.AuthorId);
            var book = _context.Books.FirstOrDefault(x => x.Id == item.BookId);

            if (author == null || book == null)
            {
                return Convert.ToBoolean(await _context.SaveChangesAsync());
            }

            _context.AuthorsBooks.Add(item);
            return Convert.ToBoolean(await _context.SaveChangesAsync());
        }

        public Task<bool> Update(AuthorsBooks item)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<AuthorsBooks>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Book>> Find(Author item)
        {
            return await _context.Books.Where(x => x.AuthorsBooks.Any(ab => ab.AuthorId == item.Id)).ToListAsync();
        }
    }
}
