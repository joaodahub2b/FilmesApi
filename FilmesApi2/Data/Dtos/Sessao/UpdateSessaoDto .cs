using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Data.Dtos
{
    public class UpdateSessaoDto
    {
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime? HorarioEncerramento { get; set; }
    }
}
