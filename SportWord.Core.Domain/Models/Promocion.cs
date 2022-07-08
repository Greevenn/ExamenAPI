using System;
using System.Collections.Generic;
using System.Text;

namespace SportWord.Core.Domain.Models
{
     public class Promocion
    {
        public Guid promocion_id { get; set; }
        public string titulo { get; set; }
        public int producto_id { get; set; }


        public List <Productos> Productos { get; set; }
       

    }
}
