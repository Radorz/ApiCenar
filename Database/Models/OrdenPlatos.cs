using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class OrdenPlatos
    {
        public int Id { get; set; }
        public int? IdPlato { get; set; }
        public int? IdOrden { get; set; }

        public virtual Ordenes IdOrdenNavigation { get; set; }
        public virtual Platos IdPlatoNavigation { get; set; }
    }
}
