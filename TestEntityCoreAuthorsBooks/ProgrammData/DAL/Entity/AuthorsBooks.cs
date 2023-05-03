using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity
{
    [Table("AuthorsBooks")]
    public class AuthorsBooks : BaseEntity
    {
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Country { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }
    }
}
