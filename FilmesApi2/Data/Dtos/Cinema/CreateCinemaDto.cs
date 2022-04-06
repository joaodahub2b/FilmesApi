using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Data.Dtos
{
    public class CreateCinemaDto
    {
        [Required(ErrorMessage = "Campo Diretor é Obrigatório")]
        public string? Nome { get; set; }
        public int EnderecoId { get; set; }
    }
}
