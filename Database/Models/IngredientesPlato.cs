using System;
using System.Collections.Generic;

namespace Database.Models
{
    public partial class IngredientesPlato
    {
        public int Id { get; set; }
        public int? IdIngrediente { get; set; }
        public int? IdPlato { get; set; }

        public virtual Ingredientes IdIngredienteNavigation { get; set; }
        public virtual Platos IdPlatoNavigation { get; set; }
    }
}
