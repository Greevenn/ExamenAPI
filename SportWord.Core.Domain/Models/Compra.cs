using System;
using System.Collections.Generic;
using System.Text;

namespace SportWord.Core.Domain.Models
{
     public class Compra
    {
        public Guid compra_id { get; set; }
        public string producto_id { get; set; }
        public string email { get; set; }
        public string usuario_name { get; set; }
        public int cantidad { get; set; }
        public double total { get; set; }

        public DateTime Fecha_compra { get; set; }
        
     
     
        public User Users { get; set; }

    }
}
