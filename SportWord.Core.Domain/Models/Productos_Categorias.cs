using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportWord.Core.Domain.Models
{
    public class Productos_Categorias
    {
        public Guid producto_id { get; set; }
        public Guid categoria_id { get; set; }
  
        [ForeignKey("producto_id")]
        public Productos Productos { get; set; }

        [ForeignKey("categoria_id")]
        public Categorias Categorias { get; set; }

    }
}
