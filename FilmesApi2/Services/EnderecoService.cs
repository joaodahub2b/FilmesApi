using AutoMapper;
using FilmesApi2.Data.Dtos.Endereco;
using FluentResults;

namespace FilmesApi2.Services
{
    public class EnderecoService
    {
        private filmedbContext _context;
        private IMapper _mapper;

        public EnderecoService(filmedbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ReadEnderecoDto AdicionaEndereco(CreateEnderecoDto enderecoDto)
        {
            Endereco endereco = _mapper.Map<Endereco>(enderecoDto);
            _context.Enderecos.Add(endereco);
            _context.SaveChanges();

            return _mapper.Map<ReadEnderecoDto>(endereco);
        }

        public List<ReadEnderecoDto> RecuperaEndereco(string? nomeDoBairro = null)
        {
            List<Endereco> enderecos = _context.Enderecos.ToList();
            if (enderecos == null)
            {
                return null;
            }
            if (!string.IsNullOrEmpty(nomeDoBairro))
            {
                /*IEnumerable<Endereco> query = from endereco in enderecos
                                            where endereco
                                            .Any(endereco => endereco.Bairro == nomeDoFilme)
                                            select cinema;*/

                Endereco endereco = _context.Enderecos
                    .FirstOrDefault(endereco => endereco.Bairro == nomeDoBairro);
                return _mapper.Map<List<ReadEnderecoDto>>(endereco);
            }
            return _mapper.Map<List<ReadEnderecoDto>>(enderecos);
        }

        internal Result AtualizarEndereco(int id, UpdateEnderecoDto enderecoDto)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco Não Encontrado");
            }
            _mapper.Map(enderecoDto, endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        internal Result DeletaEndereco(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
            if (endereco == null)
            {
                return Result.Fail("Endereco não encontrado");
            }
            _context.Remove(endereco);
            _context.SaveChanges();
            return Result.Ok();
        }

        public ReadEnderecoDto RecuperaEnderecoPorId(int id)
        {
            Endereco endereco = _context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);

            if (endereco != null)
            {
                return _mapper.Map<ReadEnderecoDto>(endereco);
            }
            return null;
        }
    }
}
