using System.ComponentModel.DataAnnotations.Schema;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity
{
    [Table("Persons")]
    public class Person : BaseEntity
    {
        public string? Address { get; set; }
    }
}
