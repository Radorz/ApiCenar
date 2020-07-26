using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public  class OrdenesDtoCreate
    {
       

        public int Id { get; set; }
        [Required(ErrorMessage = "Mesa de la orden es requerida")]

        public int? IdMesa { get; set; }
        [Required(ErrorMessage = "Platos de la orden es requerido")]

        public List<int> OrdenPlatos { get; set; }
     
    }
}
