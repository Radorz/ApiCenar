﻿using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Ordenes
    {
        public Ordenes()
        {
            OrdenPlatos = new HashSet<OrdenPlatos>();
        }

        public int Id { get; set; }
        public int? IdMesa { get; set; }
        public decimal? Subtotal { get; set; }
        public string Estado { get; set; }

        public virtual Mesas IdMesaNavigation { get; set; }
        public virtual ICollection<OrdenPlatos> OrdenPlatos { get; set; }
    }
}
