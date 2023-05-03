using AutoMapper;
using TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Repositories;

namespace TestEntityCoreAuthorsBooks.ProgrammData.BLL.ServicesImplementation
{
    public class AuthorsBooksService : IAuthorsBooksService
    {
        private readonly IRepository<AuthorsBooks> _repository;
        
        private readonly IMapper _mapper;
        public AuthorsBooksService(IRepository<AuthorsBooks> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAuthorsBooks(AuthorsBooksModel item)
        {
            AuthorsBooks mapper = _mapper.Map<AuthorsBooks>(item);
            return await _repository.Create(mapper);
        }

        public async Task<IEnumerable<BookModel>> FindAuthorsBooks(AuthorModel item)
        {
            Author temp = new Author()
            {
                Id = item.Id
            };

            IEnumerable<Book> books = await _repository.Find(temp);
            IEnumerable<BookModel> booksModel = _mapper.Map<IEnumerable<BookModel>>(books);

            return booksModel;

        }

        public Task<IEnumerable<AuthorsBooksModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<AuthorsBooksModel> Read(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(AuthorsBooksModel item)
        {
            throw new NotImplementedException();
        }
    }
}
