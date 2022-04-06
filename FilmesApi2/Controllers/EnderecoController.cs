using AutoMapper;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Data.Dtos.Endereco;
using FilmesApi2.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EnderecoController : ControllerBase
    {
        EnderecoService _enderecoService;

        public EnderecoController()
        {
        }

        [HttpPost]
        public IActionResult AdicionaEndereco([FromBody] CreateEnderecoDto enderecoDto)
        {

            ReadEnderecoDto readDto = _enderecoService.AdicionaEndereco(enderecoDto);
            return CreatedAtAction(nameof(RecuperaEnderecoPorId), new { Id = readDto.Id }, readDto);
        }
        // Antes o retorno era do tipo IEnumerable<Endereco>
        [HttpGet]
        public IActionResult RecuperaEndereco([FromQuery] string? nomeDoBairro = null)
        {
            if(nomeDoBairro == null)
            {
                List<ReadEnderecoDto> enderecoTodos = _enderecoService.RecuperaEndereco();
                return Ok(enderecoTodos);
            }
            List<ReadEnderecoDto> enderecoDto = _enderecoService.RecuperaEndereco(nomeDoBairro);
            if (enderecoDto != null) return Ok(enderecoDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaEnderecoPorId(int id)
        {
            ReadEnderecoDto enderecoDto = _enderecoService.RecuperaEnderecoPorId(id);
            if(enderecoDto != null) return Ok(enderecoDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
        {
            Result resultado = _enderecoService.AtualizarEndereco(id, enderecoDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaEndereco(int id)
        {
            Result resultado = _enderecoService.DeletaEndereco(id);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}

