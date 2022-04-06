using AutoMapper;
using FilmesApi2.Data.Dtos;
using FilmesApi2.Services;
using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace FilmesApi2.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CinemaController : ControllerBase
    {
        private CinemaService _cinemaService;

        public CinemaController(CinemaService cinemaService)
        {
            _cinemaService = cinemaService;
        }

        [HttpPost]
        public IActionResult AdicionaCinema([FromBody] CreateCinemaDto cinemaDto)
        {

            ReadCinemaDto readDto = _cinemaService.AdicionaCinema(cinemaDto);
            
            return CreatedAtAction(nameof(RecuperaCinemaPorId), new { Id = readDto.Id }, readDto);
        }

        [HttpGet]
        public IActionResult RecuperaCinema([FromQuery] string? nomeDoFilme = null)
        {
            List<ReadCinemaDto> readDto =  _cinemaService.RecuperaCinema(nomeDoFilme);
            if(readDto != null) return Ok(readDto);
            return NotFound();
            //return _context.Cinemas;
        }

        [HttpGet("{id}")]
        public IActionResult RecuperaCinemaPorId(int id)
        {
            ReadCinemaDto readDto =  _cinemaService.RecuperaCinemaPorId(id);
            if(readDto == null) return NotFound();
            return Ok(readDto);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCinema(int id, [FromBody] UpdateCinemaDto cinemaDto)
        {
            Result resultado = _cinemaService.AtualizaCinema(id, cinemaDto);
            if(resultado.IsFailed) return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCinema(int id)
        {
            Result resultado = _cinemaService.DeletaCinema(id);
            if (resultado.IsFailed) return NotFound();
            return NoContent();
        }
    }
}

