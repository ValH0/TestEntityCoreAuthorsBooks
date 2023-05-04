using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;

namespace TestEntityCoreAuthorsBooks.Models
{
    public class ShowModel : Paginated
    {
        public ShowModel() : this(1, 0, 8, 0)
        {
            //PageUiModel = new PageUiModel();
        }

        public ShowModel(
            int pageSize,
            int page,
            int recordsPerPage,
            int totalItemCount)
            : base(
                 pageSize,
                 page,
                 recordsPerPage,
                 totalItemCount)
        {

        }

        public ItemsPerPage ItemsPerPage { get; set; }

        public PageUiModel PageUiModel { get; set; }

        public List<AuthorModel> Authors { get; set; } = new List<AuthorModel>();
    }
}