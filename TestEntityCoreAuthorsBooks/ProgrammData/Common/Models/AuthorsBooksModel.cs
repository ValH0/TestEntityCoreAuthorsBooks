namespace TestEntityCoreAuthorsBooks.ProgrammData.Common.Models
{
    public class AuthorsBooksModel
    {
        public int Id { get; set; }
        public int BookId { get; set; }
        public int AuthorId { get; set; }
        public string Country { get; set; }

        //public virtual BookModel Book { get; set; }

        //public virtual AuthorModel Author { get; set; }
    }
}
