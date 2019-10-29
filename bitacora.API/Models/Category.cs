using System.Collections.Generic;

namespace bitacora.API.Models
{
   public class Category{
        public int Id{get;set;}
        public string CategoryName{get;set;}
        public string Description{get;set;}
          public List<Bitacora> Bitacoras { get; set; }
    }
}