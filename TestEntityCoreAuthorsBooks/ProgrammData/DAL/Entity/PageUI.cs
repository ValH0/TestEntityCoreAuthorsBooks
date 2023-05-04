using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity
{
    [Table("PageUIs")]
    public class PageUI: BaseEntity
    {
        public string? ItemsPerPage { get; set; }
    }
}
