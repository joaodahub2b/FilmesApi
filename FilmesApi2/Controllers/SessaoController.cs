using AutoMapper;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessoesController : ControllerBase
    {
        private SessaoServices _sessaoService;
        public  SessoesController(){
        }

        [HttpPost]
        public IActionResult AdicionaSessao([FromBody] CreateSessaoDto sessaoDto)
        {
            ReadSessaoDto readDto = _sessaoService.AdicionaSessao(sessaoDto);
            return CreatedAtAction(nameof(RecuperaSessaoPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaSessao()
        {
            List<Sessao> sessao = _sessaoService.RecuperaSessao();
            if(sessao == null) return NotFound();
            return Ok(sessao);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaSessaoPorId(int id)
        {
            ReadSessaoDto sessao = _sessaoService.RecuperaSessaoPorId(id);
            if(sessao != null) return Ok(sessao);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaSessao(int id, [FromBody] UpdateSessaoDto sessaoDto)
        {
            Result resultado = _sessaoService.AtualizaSessao(id, sessaoDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaSessao(int id)
        {
            Result resultado = _sessaoService.DeletaSessao(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}
