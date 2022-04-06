using System;
using System.Collections.Generic;

namespace FilmesApi2
{
    public partial class Filme
    {
        public Filme()
        {
            Sessaos = new HashSet<Sessao>();
        }

        public int Id { get; set; }
        public string? Titulo { get; set; }
        public string? Diretor { get; set; }
        public string? Genero { get; set; }
        public int? Duracao { get; set; }
        public int? ClassificacaoEtaria { get; set; }

        public virtual ICollection<Sessao> Sessaos { get; set; }
    }
}
