using System;
using System.Collections.Generic;
using System.Text;

namespace SportWord.Core.Domain.Models
{
    public class User_Tienda
    {
        public Guid usuario_id { get; set; }
        public Guid tienda_id { get; set; }

        public User User { get; set; }
        public Tiendas Tiendas { get; set; }
    }
}
