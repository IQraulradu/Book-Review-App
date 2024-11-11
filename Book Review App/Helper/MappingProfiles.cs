using AutoMapper;
using Book_Review_App.DTO;
using Book_Review_App.Models;

namespace Book_Review_App.Helper
{
    public class MappingProfiles : Profile 
    {

        public MappingProfiles()
        {
            CreateMap<Book, BookDto>();
            CreateMap<Category, CategoryDto>();
            CreateMap<Country, CountryDto>();
            CreateMap<Library, LibraryDto>();
        }
    }
   
}
