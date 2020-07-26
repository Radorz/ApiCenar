using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public  class MesasDTO
    {
       
        public int Id { get; set; }
        [Required(ErrorMessage = "Cantidad de personas en la mesa es requerida")]

        public int Personas { get; set; }
        [Required(ErrorMessage = "Descripcion de la mesa es requerida")]

        public string Descripcion { get; set; }
        [Required(ErrorMessage = "Estado de la mesa es requerido")]

        public string Estado { get; set; }

    }
}

