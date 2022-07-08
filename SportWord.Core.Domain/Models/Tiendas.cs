using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SportWord.Core.Domain.Models
{
     public class Tiendas
    {
        public Guid tienda_id { get; set; }
        public string nombre { get; set; }

        [ForeignKey("usuario_id")]

        public List <User_Tienda> User_Tienda { get; set; }
    }
}
