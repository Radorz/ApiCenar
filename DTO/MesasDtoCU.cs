using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DTO
{
   public class MesasDtoCU
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Cantidad de personas en la mesa es requerida")]

        public int Personas { get; set; }
        [Required(ErrorMessage = "Descripcion de la mesa es requerida")]

        public string Descripcion { get; set; }
       
    }
}
