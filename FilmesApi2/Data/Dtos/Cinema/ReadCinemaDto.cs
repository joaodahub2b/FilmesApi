using System.ComponentModel.DataAnnotations;

namespace FilmesApi2
{
    public class ReadCinemaDto
    {
        [Key]
        [Required]
        public int Id { get; set; }
        [Required(ErrorMessage = "Campo Diretor é Obrigatório")]
        public string? Nome { get; set; }
        public Endereco Endereco { get; set; }
    }
}
