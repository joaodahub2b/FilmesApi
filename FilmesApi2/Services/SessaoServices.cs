using AutoMapper;
using FilmesApi2.Data.Dtos;
using FluentResults;

namespace FilmesApi2.Services
{
    public class SessaoServices
    {
        filmedbContext _context;
        IMapper _mapper;
        public SessaoServices(filmedbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        internal ReadSessaoDto AdicionaSessao(CreateSessaoDto sessaoDto)
        {
            Sessao sessao = _mapper.Map<Sessao>(sessaoDto);
            _context.Sessaos.Add(sessao);
            _context.SaveChanges();

            return _mapper.Map<ReadSessaoDto>(sessao);
        }

        internal List<Sessao> RecuperaSessao()
        {
            return _context.Sessaos.ToList();
        }

        internal ReadSessaoDto RecuperaSessaoPorId(int id)
        {
            Sessao sessao = _context.Sessaos.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao != null)
            {
                return _mapper.Map<ReadSessaoDto>(sessao);
            }
            return null;
        }

        internal Result AtualizaSessao(int id, UpdateSessaoDto sessaoDto)
        {
            Sessao sessao = _context.Sessaos.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return Result.Fail("Sessao não Encontrada");
            }
            _mapper.Map(sessaoDto, sessao);
            _context.SaveChanges();
            return Result.Ok();
        }

        internal Result DeletaSessao(int id)
        {
            Sessao sessao = _context.Sessaos.FirstOrDefault(sessao => sessao.Id == id);
            if (sessao == null)
            {
                return Result.Fail("Sessao não encontrada");
            }
            _context.Remove(sessao);
            _context.SaveChanges();
            return Result.Ok();
        }
    }
}
