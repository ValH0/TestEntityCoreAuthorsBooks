namespace TestEntityCoreAuthorsBooks.Models
{
    public class Paginated
    {
        public Paginated() : this(1, 0, 3, 0)
        {

        }

        public Paginated(int pageSize, int page, int recordsPerPage, int totalItemCount)
        {
            PageSize = pageSize;
            TotalItemCount = totalItemCount;
            Page = page;
            RecordsPerPage = recordsPerPage;
        }

        public int PageSize;
        public int TotalItemCount;


        public string SortField { get; set; } = string.Empty;
        public string CurrentSortField { get; set; } = string.Empty;
        public string CurrentSortOrder { get; set; } = string.Empty;

        public string Term { get; set; } = string.Empty;
        public int Page { get; set; }
        public int RecordsPerPage { get; set; }
    }
}