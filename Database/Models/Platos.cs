using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Platos
    {
        public Platos()
        {
            IngredientesPlato = new HashSet<IngredientesPlato>();
            OrdenPlatos = new HashSet<OrdenPlatos>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal? Precio { get; set; }
        public int? Personas { get; set; }
        public string Categoria { get; set; }

        public virtual ICollection<IngredientesPlato> IngredientesPlato { get; set; }
        public virtual ICollection<OrdenPlatos> OrdenPlatos { get; set; }
    }
}
