using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public  class MesasStatusDTO
    {
       
        
     
        [Required(ErrorMessage = "Estado de la mesa es requerido")]

        public int Estado { get; set; }

    }
}

