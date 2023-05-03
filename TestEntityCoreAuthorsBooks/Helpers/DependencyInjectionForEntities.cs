using TestEntityCoreAuthorsBooks.ProgrammData.BLL.Services;
using TestEntityCoreAuthorsBooks.ProgrammData.BLL.ServicesImplementation;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Interfaces;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Repositories;

namespace TestEntityCoreAuthorsBooks.Helpers
{
    public static class DependencyInjectionForEntities
    {
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IAuthorService, AuthorService>();
           
           
            services.AddScoped<IBookService, BookService>();
            
            services.AddScoped<IAuthorsBooksService, AuthorsBooksService>();
           

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
           

            services.AddScoped<IRepository<Author>, AuthorRepository>();
           
           
            services.AddScoped<IRepository<Book>, BookRepository>();

           
            services.AddScoped<IRepository<AuthorsBooks>, AuthorsBooksRepository>();
            
            return services;
        }
    }
}
