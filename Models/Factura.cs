using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Models
{
    public class Factura
    {
        public int NFactura { get; set; }
        public DateOnly Fecha { get; set; }
        public int IdCliente { get; set; }
        public int TotalFactura { get; set; }
    }
}