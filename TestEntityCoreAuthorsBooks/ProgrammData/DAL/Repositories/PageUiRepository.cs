using Microsoft.EntityFrameworkCore;
using TestEntityCoreAuthorsBooks.Data;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Repositories
{
    public class PageUiRepository : IRepository<PageUI>
    {
        private readonly ApplicationDbContext _context;

        public PageUiRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(PageUI item)
        {
            try
            {
                if (!_context.PageUIs.Any())
                {
                    await _context.PageUIs.AddAsync(item);
                    _context.Entry(item).State = EntityState.Added;
                    await _context.SaveChangesAsync();

                    int id = _context.PageUIs.Entry(item).Entity.Id;

                    return id;
                }

                return -1;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<Book>> Find(Author item)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<PageUI>> GetAll()
        {
            try
            {
                return await GetAllQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PageUI> Read(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(PageUI item)
        {
            try
            {
                _context.PageUIs.Attach(item);
                _context.Entry(item).State = EntityState.Modified;
                return Convert.ToBoolean(await _context.SaveChangesAsync());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IQueryable<PageUI>> GetAllQueryable()
        {
            try
            {
                var pageUIs = await _context.PageUIs.AsNoTracking().ToListAsync();
                return pageUIs.AsQueryable();
            }
            catch (Exception ex)
            {
                throw ex;
            }         
        }
    }
}
