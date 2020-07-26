using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class TiposEstados
    {
        public TiposEstados()
        {
            Mesas = new HashSet<Mesas>();
        }

        public int Id { get; set; }
        public string EstadoDesc { get; set; }

        public virtual ICollection<Mesas> Mesas { get; set; }
    }
}
