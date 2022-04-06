using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Data.Dtos.Endereco
{
    public class CreateEnderecoDto
    {
        [Required(ErrorMessage = "O Logradouro é obrigatório")]
        public string? Logradouro { get; set; }
        [Required(ErrorMessage = "O Bairro é obrigatório")]
        public string? Bairro { get; set; }
        [Range(1, 8, ErrorMessage = "O Número precisa ter entre 1 e 8 digitos")]
        public int? Numero { get; set; }
    }
}
