using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity
{
    public class BaseEntity
    {
        public BaseEntity()
        {

        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
    }
}
