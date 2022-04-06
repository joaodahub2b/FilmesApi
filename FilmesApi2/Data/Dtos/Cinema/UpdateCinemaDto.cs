using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Data.Dtos
{
    public class UpdateCinemaDto
    {
        [Required(ErrorMessage = "Campo Diretor é Obrigatório")]
        public string? Nome { get; set; }
    }
}
