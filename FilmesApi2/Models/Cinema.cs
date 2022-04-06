using System;
using System.Collections.Generic;

namespace FilmesApi2
{
    public partial class Cinema
    {
        public Cinema()
        {
            Sessaos = new HashSet<Sessao>();
        }

        public int Id { get; set; }
        public string? Nome { get; set; }
        public int? EnderecoId { get; set; }

        public virtual Endereco? Endereco { get; set; }
        public virtual ICollection<Sessao> Sessaos { get; set; }
    }
}
