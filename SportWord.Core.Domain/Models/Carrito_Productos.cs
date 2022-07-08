using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportWord.Core.Domain.Models
{
     public class Carrito_Productos
    {
        public Guid carrito_id { get; set; }
        public Guid producto_id { get; set; }


        [ForeignKey("producto_id")] //Carrito_Producto
        public Carrito Carrito { get; set; }
        [ForeignKey("carrito_id")] //Carrito_Producto
       

        public Productos Productos { get; set; }
       
    }
}
