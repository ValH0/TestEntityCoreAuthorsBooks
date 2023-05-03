using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity
{
    [Table("Authors")]
    public class Author : BaseEntity
    {
        public Author()
        {
            AuthorsBooks = new HashSet<AuthorsBooks>();
            Employees = new HashSet<Employee>();
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<AuthorsBooks> AuthorsBooks { get; set; }
    }
}
