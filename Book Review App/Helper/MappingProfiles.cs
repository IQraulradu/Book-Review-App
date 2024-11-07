using AutoMapper;
using Book_Review_App.DTO;
using Book_Review_App.Models;

namespace Book_Review_App.Helper
{
    public class MappingProfiles : Profile 
    {

        public MappingProfiles()
        {
            CreateMap<Book, BookDto>()
                .ForMember(dest => dest.Categories,
                opt => opt
                .MapFrom(src => src.BookCategories
                .Select(bc => bc.Category)));
            CreateMap<BookCategory, CategoryDto>().ConvertUsing(bc => new CategoryDto
            {
                Name = bc.Category.Name,
            });

            CreateMap<Category, CategoryDto>();
        }
    }
   
}
