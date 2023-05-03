using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TestEntityCoreAuthorsBooks.ProgrammData.Common.Models
{
    public class BookModel
    {
        public int Id { get; set; }

        [Required]
        public string Publisher { get; set; }

        public string Name { get; set; }

        public override string ToString()
        {
            StringBuilder builder = new StringBuilder();

            builder.AppendLine("Id|" + Id);
            builder.AppendLine("|Publisher|" + Publisher);
            builder.AppendLine("|Name|" + Name);

            return builder.ToString();
        }
    }
}
