using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class PlatosDto
    {
        public int id { get; set; }
        [Required(ErrorMessage = "Nombre de Plato es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "Precio de Plato es requerido")]
        public decimal Precio { get; set; }
        [Required(ErrorMessage = "Personas de Plato es requerido")]
        public int Personas { get; set; }
        [Required(ErrorMessage = "Categoria de Plato es requerido")]

        public string Categoria { get; set; }
        [Required(ErrorMessage = "Ingredientes de Plato es requerido")]

        public List<IngredientesDto> Ingredientes { get; set; }
        

    }
}
