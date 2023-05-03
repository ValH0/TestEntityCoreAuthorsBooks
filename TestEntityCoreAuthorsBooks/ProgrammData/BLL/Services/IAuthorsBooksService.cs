using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;

namespace TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services
{
    public interface IAuthorsBooksService
    {
        Task<IEnumerable<AuthorsBooksModel>> GetAll();
        Task<AuthorsBooksModel> Read(int id);
        Task<IEnumerable<BookModel>> FindAuthorsBooks(AuthorModel item);
        Task<bool> CreateAuthorsBooks(AuthorsBooksModel item);
        Task<bool> Update(AuthorsBooksModel item);
        Task<bool> Remove(int id);
    }
}
