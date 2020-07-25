using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Mesas
    {
        public Mesas()
        {
            Ordenes = new HashSet<Ordenes>();
        }

        public int Id { get; set; }
        public int? Personas { get; set; }
        public string Descripcion { get; set; }
        public string Estado { get; set; }

        public virtual ICollection<Ordenes> Ordenes { get; set; }
    }
}
