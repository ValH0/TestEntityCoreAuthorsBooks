using Microsoft.AspNetCore.Identity;

namespace TestEntityCoreAuthorsBooks.ProgrammData.Common.Data
{
    public class ApplicationUser : IdentityUser
    {
        public string? OriginCountry { get; set; }

        public DateTime? BirthDay { get; set; }
    }
}
