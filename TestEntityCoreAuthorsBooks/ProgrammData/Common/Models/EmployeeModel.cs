using TestEntityCoreAuthorsBooks.ProgrammData.Common.ViewModels;

namespace TestEntityCoreAuthorsBooks.ProgrammData.Common.Models
{
    public class EmployeeModel
    {
        public int Id { get; set; }

        public int AuthorEmployeeId { get; set; }
        public int PersonId { get; set; }
        public Dept Department { get; set; }

        public string PhotoPath { get; set; }

    }
}
