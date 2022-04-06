using System.ComponentModel.DataAnnotations;

namespace FilmesApi2.Data.Dtos
{
    public class ReadSessaoDto
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime? HorarioEncerramento { get; set; }
    }
}
