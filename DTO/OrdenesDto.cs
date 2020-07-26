using System;
using System.Collections.Generic;

namespace DTO
{
    public  class OrdenesDto
    {
       
        public int Id { get; set; }
        public int? IdMesa { get; set; }
        public decimal? Subtotal { get; set; }
        public string Estado { get; set; }
        public  List<PlatosDto> OrdenPlatos { get; set; }
    }
}
