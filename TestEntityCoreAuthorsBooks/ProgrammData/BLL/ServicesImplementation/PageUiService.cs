using AutoMapper;
using TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces;

namespace TestEntityCoreAuthorsBooks.ProgrammData.BLL.ServicesImplementation
{
    public class PageUiService : IPageUiService
    {
        private readonly IRepository<PageUI> _repository;
        private readonly IMapper _mapper;       

        public PageUiService(IMapper mapper,
            IRepository<PageUI> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<int> CreatePageUi(PageUiModel item)
        {
            try
            {
                PageUI mapPageUi = _mapper.Map<PageUI>(item);
                return await _repository.Create(mapPageUi);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<PageUiModel>> GetAllPageUis()
        {
            try
            {
                IEnumerable<PageUI> pageUis = await _repository.GetAll();
                IEnumerable<PageUiModel> mapPageUi = _mapper.Map<IEnumerable<PageUiModel>>(pageUis);

                return mapPageUi;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<PageUiModel> GetPageUiById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> RemovePageUi(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> UpdatePageUi(PageUiModel item)
        {
            try
            {
                PageUI pageUI = _mapper.Map<PageUI>(item);
                return await _repository.Update(pageUI);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
