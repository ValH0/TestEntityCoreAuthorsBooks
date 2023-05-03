using AutoMapper;
using TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces;

namespace TestEntityCoreAuthorsBooks.ProgrammData.BLL.ServicesImplementation
{
    public class BookService : IBookService
    {
        private readonly IRepository<Book> _repository;
        private readonly IMapper _mapper;

        public BookService(IRepository<Book> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateBook(BookModel item)
        {
            Book mapBook = _mapper.Map<Book>(item);
            return await _repository.Create(mapBook);
        }

        public async Task<IEnumerable<BookModel>> GetAllBooks()
        {
            IEnumerable<Book> books = await _repository.GetAll();
            IEnumerable<BookModel> mapBooks = _mapper.Map<IEnumerable<BookModel>>(books);

            return mapBooks;
        }

        public Task<BookModel> GetBookById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemoveBook(int id)
        {
            return _mapper.Map<bool>(await _repository.Remove(id));
        }

        public Task<bool> UpdateBook(BookModel item)
        {
            throw new NotImplementedException();
        }
    }
}
