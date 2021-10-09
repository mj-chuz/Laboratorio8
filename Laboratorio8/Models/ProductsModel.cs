using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Laboratorio8.Models
{
    public class ProductsModel
    {
        public int id { get; set; }
        public int cantidad { get; set; }
        public string nombre { get; set; }
        public int precio { get; set; }
    }
}