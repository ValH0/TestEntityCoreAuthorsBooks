using AutoMapper;
using TestEntityCoreAuthorsBooks.ProgrammData.Common.Models;
using TestEntityCoreAuthorsBooks.ProgrammData.DAL.Entity;

namespace TestEntityCoreAuthorsBooks.ProgrammData.BLL.AutomapperProfiles
{
    public class EntityDtoProfile : Profile
    {
        public EntityDtoProfile()
        {
            CreateMap<AuthorModel, Author>()
                  .ForMember(
                      dest => dest.FirstName,
                      opt => opt.MapFrom(src => src.FirstName));

            CreateMap<Author, AuthorModel>()
                    .ForMember(
                         dest => dest.FirstName,
                         opt => opt.MapFrom(src => src.FirstName));

            /////
            CreateMap<PersonModel, Person>()
                 .ForMember(
                     dest => dest.Address,
                     opt => opt.MapFrom(src => src.Address));

            CreateMap<Person, PersonModel>()
                    .ForMember(
                         dest => dest.Address,
                         opt => opt.MapFrom(src => src.Address));


            /////
            CreateMap<PageUiModel, PageUI>()
                 .ForMember(
                     dest => dest.ItemsPerPage,
                     opt => opt.MapFrom(src => src.ItemsPerPage));

            CreateMap<PageUI, PageUiModel>()
                    .ForMember(
                         dest => dest.ItemsPerPage,
                         opt => opt.MapFrom(src => src.ItemsPerPage));


            /////
            CreateMap<AuthorViewModel, AuthorModel>()
                   .ForMember(
                       dest => dest.LastName,
                       opt => opt.MapFrom(src => src.LastName));

            CreateMap<AuthorModel, AuthorViewModel>()
                    .ForMember(
                         dest => dest.LastName,
                         opt => opt.MapFrom(src => src.LastName));


            /////
            CreateMap<EmployeeModel, Employee>()
                  .ForMember(
                      dest => dest.PhotoPath,
                      opt => opt.MapFrom(src => src.PhotoPath));

            CreateMap<Employee, EmployeeModel>()
                    .ForMember(
                         dest => dest.PhotoPath,
                         opt => opt.MapFrom(src => src.PhotoPath));

            /////
            CreateMap<BookModel, Book>()
                  .ForMember(
                      dest => dest.Name,
                      opt => opt.MapFrom(src => src.Name));

            CreateMap<Book, BookModel>()
                    .ForMember(
                         dest => dest.Name,
                         opt => opt.MapFrom(src => src.Name));


            /////
            CreateMap<AuthorsBooksModel, AuthorsBooks>()
                 .ForMember(
                     dest => dest.Country,
                     opt => opt.MapFrom(src => src.Country));

            CreateMap<AuthorsBooks, AuthorsBooksModel>()
                    .ForMember(
                         dest => dest.Country,
                         opt => opt.MapFrom(src => src.Country));
        }
    }
}
