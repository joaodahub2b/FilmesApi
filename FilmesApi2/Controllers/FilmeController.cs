using AutoMapper;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FilmeController : ControllerBase
    {
        private FilmeService _filmeService;
        public FilmeController(FilmeService filme_service)
        {
            this._filmeService = filme_service;
        }

        [HttpPost]
        public IActionResult AdicionaFilme([FromBody] CreateFilmeDto filmeDto)
        {
            ReadFilmeDto readDto = _filmeService.AdicionaFilme(filmeDto);
            return CreatedAtAction(nameof(RecuperaFilmesPorId), new { Id = readDto.Id }, readDto);
        }
        /* ---->>MÉTODO A SER IMPLEMENTADO AINDA<<---------
        //
        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = NULL)
        {
            
            return NotFound();
            //return _context.Filmes;
        }*/

        [HttpGet]
        public IActionResult RecuperaFilmes([FromQuery] int? classificacaoEtaria = null)
        {
            List<ReadFilmeDto>  readDto = _filmeService.RecuperaFilmes(classificacaoEtaria);
            if (readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaFilmesPorId(int id)
        {
            ReadFilmeDto readDto = _filmeService.RecuperaFilmesPorId(id);
            if(readDto != null) return Ok(readDto);
            return NotFound();
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
        {
            Result resultado = _filmeService.AtualizaFilme(id, filmeDto);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaFilme(int id)
        {
            Result resultado = _filmeService.DeletaFilme(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}

