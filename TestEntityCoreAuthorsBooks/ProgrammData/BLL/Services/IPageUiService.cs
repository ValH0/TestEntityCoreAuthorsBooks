using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;

namespace TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services
{
    public interface IPageUiService
    {
        Task<IEnumerable<PageUiModel>> GetAllPageUis();
        Task<PageUiModel> GetPageUiById(int id);
        Task<bool> UpdatePageUi(PageUiModel item);
        Task<int> CreatePageUi(PageUiModel item);
        Task<bool> RemovePageUi(int id);
    }
}
