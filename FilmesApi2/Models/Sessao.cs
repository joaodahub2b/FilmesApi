using System;
using System.Collections.Generic;

namespace FilmesApi2
{
    public partial class Sessao
    {
        public int Id { get; set; }
        public int FilmeId { get; set; }
        public int CinemaId { get; set; }
        public DateTime? HorarioEncerramento { get; set; }

        public virtual Cinema Cinema { get; set; } = null!;
        public virtual Filme Filme { get; set; } = null!;
    }
}
