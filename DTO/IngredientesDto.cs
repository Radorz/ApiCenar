using System;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public class IngredientesDto
    {
        public int id { get; set; }
        [Required(ErrorMessage ="Nombre de ingrediente es requerido")]
        public string Nombre { get; set; }

    }
}
