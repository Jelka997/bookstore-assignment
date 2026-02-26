using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Settings
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            CreateMap<Book, BookDto>()
                  .ForMember(dest => dest.YearCount,
                  opt => opt.MapFrom(src => DateTime.Now.Year - src.PublishedDate.Year)
                  ).ReverseMap();

            CreateMap<Book, BookDetailsDto>().ReverseMap();
            CreateMap<RegistrationDto, ApplicationUser>();
            CreateMap<ApplicationUser, ProfileDto>();
        }
    }
}
