using AutoMapper;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Data.Dtos.Endereco;

namespace FilmesApi2.Profiles
{
    public class EnderecoProfile : Profile
    {

        public EnderecoProfile()
        {
            CreateMap<CreateEnderecoDto, Endereco>(); 
            CreateMap<Endereco, ReadEnderecoDto>(); 
            CreateMap<UpdateEnderecoDto, Endereco>(); 
        }
        
    }
}
