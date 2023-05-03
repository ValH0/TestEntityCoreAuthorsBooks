using System.ComponentModel;

namespace TestEntityCoreAuthorsBooks.Models
{
    public enum ItemsPerPage
    {
        [Description("2")]
        Two = 2,
        [Description("4")]
        Four = 4,
        [Description("6")]
        Six = 6,
    }
}