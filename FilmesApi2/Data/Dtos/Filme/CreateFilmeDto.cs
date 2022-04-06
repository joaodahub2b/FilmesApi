using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Data.Dtos
{
    public class CreateFilmeDto
    {
        [Required(ErrorMessage = "Campo Título é Obrigatório")]
        public string? Titulo { get; set; }
        [Required(ErrorMessage = "Campo Diretor é Obrigatório")]
        public string? Diretor { get; set; }
        [StringLength(30, ErrorMessage = "Gênero não pode passar de 30 caracteres")]
        public string? Genero { get; set; }
        [Range(1, 600, ErrorMessage = "Duração Deve ter entre 1 e 600 minutos")]
        public int? Duracao { get; set; }
    }
}
