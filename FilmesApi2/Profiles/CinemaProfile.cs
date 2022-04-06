using AutoMapper;
using FilmesApi2.Data.Dtos;

namespace FilmesApi2.Profiles
{
    public class CinemaProfile : Profile
    {

        public CinemaProfile()
        {
            CreateMap<CreateCinemaDto, Cinema>();
            CreateMap<Cinema, ReadCinemaDto>(); 
            CreateMap<UpdateCinemaDto, Cinema>(); 
        }
        
    }
}
