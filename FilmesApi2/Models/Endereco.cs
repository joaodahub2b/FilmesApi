using System;
using System.Collections.Generic;

namespace FilmesApi2
{
    public partial class Endereco
    {
        public Endereco()
        {
            Cinemas = new HashSet<Cinema>();
        }

        public int Id { get; set; }
        public string? Logradouro { get; set; }
        public string? Bairro { get; set; }
        public int? Numero { get; set; }

        public virtual ICollection<Cinema> Cinemas { get; set; }
    }
}
