using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportWord.Core.Domain.Models
{
     public class User_Producto
    {
        public Guid usuario_id { get; set; }
        public Guid producto_id { get; set; }

        [ForeignKey("usuario_id")]
        public User User { get; set; }

        [ForeignKey("producto_id")]
        public Productos Productos { get; set; }
  
        

     }
}
