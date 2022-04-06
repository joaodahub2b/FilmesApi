using AutoMapper;
using UsuariosApi.Data.Dtos;
using UsuariosApi.Models;

namespace UsuariosApi.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            // Mapeamento De um CreateUsuarioDto para um Usuario
            CreateMap<CreateUsuarioDto, Usuario>();
        }
    }
}
