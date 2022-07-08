using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportWord.Core.Domain.Models
{
     public class Carrito
    {
        public Guid carrito_id { get; set; }

       
       public List<Carrito_Productos> carrito_productos { get; set; }
        
     
     }
}
