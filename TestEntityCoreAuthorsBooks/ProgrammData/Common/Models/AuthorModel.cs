using System.ComponentModel.DataAnnotations;
using System.Text;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.ViewModels;

namespace TestEntityCoreAuthorsBooks.ProgrammData.Common.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required]
        public Dept Department { get; set; }

        public string PhotoPath { get; set; }

        //public override string ToString()
        //{
        //    StringBuilder builder = new StringBuilder();

        //    builder.AppendLine("Id|" + Id);
        //    builder.AppendLine("|FirstName|" + FirstName);
        //    builder.AppendLine("|LastName|" + LastName);

        //    return builder.ToString();
        //}
    }
    public class AuthorViewModel : AuthorModel
    {
        public bool HasCustomImage { get; set; }
    }
}
