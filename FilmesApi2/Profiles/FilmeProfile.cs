using AutoMapper;
using FilmesApi2.Data.Dtos;

namespace FilmesApi2.Profiles
{
    public class FilmeProfile : Profile
    {

        public FilmeProfile()
        {
            CreateMap<CreateFilmeDto, Filme>(); 
            CreateMap<Filme, ReadFilmeDto>(); 
            CreateMap<UpdateFilmeDto, Filme>(); 
        }
        
    }
}
