using System;
using System.Collections.Generic;
using System.Text;

namespace SportWord.Core.Domain.Models
{
     public class Categorias
    {
        public Guid categoria_id { get; set; }
        public string nombre { get; set; }
        
        public List<Productos_Categorias> Productos_Categorias { get; set; }
        
       
    }
}
