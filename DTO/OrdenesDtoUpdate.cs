using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public  class OrdenesDtoUpdate
    {
        [Required(ErrorMessage = "Platos de la orden es requerido")]

        public List<int> OrdenPlatos { get; set; }
     
    }
}
