using AutoMapper;
using TestEntityCoreAuthorsBooks.Models;
using TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces;

namespace TestEntityCoreAuthorsBooks.ProgrammData.BLL.ServicesImplementation
{
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _repository;

        private readonly IMapper _mapper;

        public AuthorService(IRepository<Author> repository,
            IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<bool> CreateAuthor(AuthorModel item)
        {
            Author mapper = _mapper.Map<Author>(item);
            return await _repository.Create(mapper);
        }

        public async Task<IEnumerable<AuthorModel>> GetAllAuthors()
        {
            IEnumerable<Author> authors = await _repository.GetAll();

            IEnumerable<AuthorModel> authorModels = _mapper.Map<IEnumerable<AuthorModel>>(authors);

            return authorModels;
        }

        public async Task<AuthorModel> GetAuthorById(int id)
        {
            Author author = await _repository.Read(id);
            return _mapper.Map<AuthorModel>(author);
        }

        public async Task<bool> RemoveAuthor(int id)
        {
            return _mapper.Map<bool>(await _repository.Remove(id));
        }

        public async Task<bool> UpdateAuthor(AuthorModel item)
        {
            Author author = _mapper.Map<Author>(item);
            return await _repository.Update(author);
        }

        public async Task<ShowModel> Search(ShowModel pageModel)
        {
            IEnumerable<Author> queryable = await _repository.GetAll();
            ShowModel model = pageModel;

            if (!string.IsNullOrEmpty(model.Term))
            {
                queryable = queryable.Where
                (c => c.Id.ToString().Equals(model.Term)
                          || c.FirstName.Equals(model.Term)
                          || c.LastName.Equals(model.Term));
            }

            model.TotalItemCount = queryable.Count();
            model.PageSize = (int)Math.Ceiling((double)model.TotalItemCount / model.RecordsPerPage);
            model.Page = model.Page > model.PageSize || model.Page < 1 ? 1 : model.Page;

            var skipped = (model.Page - 1) * model.RecordsPerPage;
            queryable = queryable.Skip(skipped).Take(model.RecordsPerPage);

            model.Authors = queryable.Select(u => new AuthorModel
            {
                Id = u.Id,
                LastName = u.LastName,
                FirstName = u.FirstName
            }).ToList();

            return model;
        }
    }
}
