using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;


namespace SportWord.Core.Domain.Models
{
    public class Productos
    {
        public Guid producto_id { get; set; }
        public string nombre { get; set; }
        public string imagen { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
     
      
        public List<Productos_Categorias> productos_Categorias { get; set; }

        
        public List<Carrito_Productos> carrito_productos { get; set; }

        public List <User_Producto> user_producto { get; set; }

       //[ForeignKey("producto_id")]
        public Promocion Promocion { get; set; }
  

    }
}
