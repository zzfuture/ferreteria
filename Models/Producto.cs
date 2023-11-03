using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Models
{
    public class Producto : BaseModel
    {
        public string Nombre { get; set; }
        public int PrecioUnit { get; set; }
        public int Cantidad { get; set; }
        public int Valor { get; set; }
        public int StockMin { get; set; }
        public int StockMax { get; set; }
    }
}