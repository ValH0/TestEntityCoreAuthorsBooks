using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity
{
    [Table("Books")]
    public class Book : BaseEntity
    {
        public string Publisher { get; set; }
        public string Name { get; set; }

        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; } = new HashSet<AuthorsBooks>();
    }
}
