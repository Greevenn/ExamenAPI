using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using SportWord.Core.Domain.Models;

namespace SportWord.Core.Domain.Models
{
      public class User
      {
        public Guid usuario_id { get; set; }
        public string usuario_name { get; set; }
        public string email { get; set; }
        public string contraseña { get; set; }

        public string tipo { get; set; }
  



        public List<Compra> Compras { get; set; }
   

        public List<User_Producto> user_producto { get; set; }

        public List <User_Tienda> User_Tienda { get; set; }

    }
}
