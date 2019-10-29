using System;
using System.Collections.Generic;

namespace bitacora.API.Models
{
    public class Bitacora
    {
        public int bitacoraId { get; set; }
         public DateTime bitacoraFecha { get; set; }
        public DateTime bitacoraHoraInicio { get; set; }
         public DateTime bitacoraHoraFinal { get; set; }

         public int category_Id { get; set; }
        public Category Category {get;set;}
          
    }
}