using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.Data;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.ViewModels;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;

namespace TestEntityCoreAuthorsBooks.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<AuthorsBooks> AuthorsBooks { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Person> Persons { get; set; }
        public virtual DbSet<PageUI> PageUIs { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();

            SeedDataBase();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasKey(m => m.Id);
            modelBuilder.Entity<Book>().HasKey(m => m.Id); ;
            modelBuilder.Entity<AuthorsBooks>().HasKey(m => m.Id);
            modelBuilder.Entity<Employee>().HasKey(m => m.Id);
            modelBuilder.Entity<Person>().HasKey(m => m.Id);
            modelBuilder.Entity<PageUI>().HasKey(m => m.Id);

            base.OnModelCreating(modelBuilder);

            foreach (var foreighKey in modelBuilder.Model.GetEntityTypes()
                                                        .SelectMany(e => e.GetForeignKeys()))
            {
                foreighKey.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }

        public async Task<bool> SeedDataBase()
        {
            if (Books.Any() ||
                Authors.Any() ||
                AuthorsBooks.Any() ||
                Employees.Any() ||
                Persons.Any() ||
                PageUIs.Any())
            {
                return false;
            }


            ////////////////////////////////////////////////////
            Author author1 = new Author()
            {
                FirstName = "First1 Name1",
                LastName = "Last1 Name1",
            };

            Author author2 = new Author()
            {
                FirstName = "First2 Name2",
                LastName = "Last2 Name2",
            };

            Author author3 = new Author()
            {
                FirstName = "First3 Name3",
                LastName = "Last3 Name3",
            };

            Author author4 = new Author()
            {
                FirstName = "First4 Name4",
                LastName = "Last4 Name4",
            };

            /////////////////////////////////////////////////////////
            Person person1 = new Person()
            {
                Address = "Address1"
            };

            Person person2 = new Person()
            {
                Address = "Address2"
            };

            Person person3 = new Person()
            {
                Address = "Address3"
            }; 

            Person person4 = new Person()
            {
                Address = "Address4"
            };

            //////////////////////////////////////////////////////////
            Employee employee1 = new Employee()
            {
                Author = author1,
                Person = person1,
                Department = Dept.Action,
                PhotoPath = "/default/noimage.jpg"
            };

            Employee employee2 = new Employee()
            {
                Author = author2,
                Person = person2,
                Department = Dept.Action,
                PhotoPath = "/default/noimage.jpg"
            };

            Employee employee3 = new Employee()
            {
                Author = author3,
                Person = person3,
                Department = Dept.Fantasy,
                PhotoPath = "/default/noimage.jpg"
            };

            Employee employee4 = new Employee()
            {
                Author = author4,
                Person = person4,
                Department = Dept.Horror,
                PhotoPath = "/default/noimage.jpg"
            };

            //////////////////////////////////
            Book book1 = new Book()
            {
                Publisher = "Publisher 1",
                Name = "Name 1",
            };

            Book book2 = new Book()
            {
                Publisher = "Publisher 2",
                Name = "Name 2",
            };

            Book book3 = new Book()
            {
                Publisher = "Publisher 3",
                Name = "Name 3",
            };

            Book book4 = new Book()
            {
                Publisher = "Publisher 4",
                Name = "Name 4",
            };

            Book book5 = new Book()
            {
                Publisher = "Publisher 5",
                Name = "Name 5",
            };

            Book book6 = new Book()
            {
                Publisher = "Publisher 6",
                Name = "Name 6",
            };
            //////////////////////////////////////////


            AuthorsBooks authorsBooks1 = new AuthorsBooks()
            {
                Author = author1,
                AuthorId = author1.Id,
                Book = book1,
                BookId = book1.Id,
                Country = "Country 1",
            };

            AuthorsBooks authorsBooks2 = new AuthorsBooks()
            {
                Author = author1,
                AuthorId = author1.Id,
                Book = book2,
                BookId = book2.Id,
                Country = "Country 2",
            };

            AuthorsBooks authorsBooks3 = new AuthorsBooks()
            {
                Author = author2,
                AuthorId = author2.Id,
                Book = book3,
                BookId = book3.Id,
                Country = "Country 3",
            };

            AuthorsBooks authorsBooks4 = new AuthorsBooks()
            {
                Author = author2,
                AuthorId = author2.Id,
                Book = book4,
                BookId = book4.Id,
                Country = "Country 4",
            };

            AuthorsBooks authorsBooks5 = new AuthorsBooks()
            {
                Author = author3,
                AuthorId = author3.Id,
                Book = book5,
                BookId = book5.Id,
                Country = "Country 5",
            };

            AuthorsBooks authorsBooks6 = new AuthorsBooks()
            {
                Author = author4,
                AuthorId = author4.Id,
                Book = book6,
                BookId = book6.Id,
                Country = "Country 6",
            };

            PageUI pageUI1 = new PageUI()
            {
                ItemsPerPage = "2",
            };

            PageUIs.AddRange(new[] { pageUI1 });

            Authors.AddRange(new[] { author1, author2, author3, author4 });
            Persons.AddRange(new[] {person1,person2, person3, person4 });


            Employees.AddRange(new[] { employee1, employee2, employee3, employee4 });

            Books.AddRange(new[] { book1, book2, book3, book4, book5, book6 });

            AuthorsBooks.AddRange(new[] { authorsBooks1, authorsBooks2, authorsBooks3, authorsBooks4, authorsBooks5, authorsBooks6 });

            return Convert.ToBoolean(await SaveChangesAsync());
        }
    }
}