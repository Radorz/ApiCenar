using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class Ingredientes
    {
        public Ingredientes()
        {
            IngredientesPlato = new HashSet<IngredientesPlato>();
        }

        public int Id { get; set; }
        public string Nombre { get; set; }

        public virtual ICollection<IngredientesPlato> IngredientesPlato { get; set; }
    }
}
