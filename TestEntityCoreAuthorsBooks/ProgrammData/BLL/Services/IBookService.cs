using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;

namespace TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services
{
    public interface IBookService
    {
        Task<IEnumerable<BookModel>> GetAllBooks();
        Task<BookModel> GetBookById(int id);
        Task<bool> UpdateBook(BookModel item);
        Task<bool> CreateBook(BookModel item);
        Task<bool> RemoveBook(int id);
    }
}
