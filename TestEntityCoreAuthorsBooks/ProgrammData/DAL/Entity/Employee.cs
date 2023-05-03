using System.ComponentModel.DataAnnotations.Schema;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.ViewModels;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity
{
    [Table("Employees")]
    public class Employee : BaseEntity
    {
        public Dept Department { get; set; }

        public string PhotoPath { get; set; }

        public int AuthorEmployeeId { get; set; }

        [ForeignKey("AuthorEmployeeId")]
        public virtual Author Author { get; set; }

        public int PersonId { get; set; }

        [ForeignKey("PersonId")]
        public virtual Person Person { get; set; }
    }
}
