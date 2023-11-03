using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Models
{
    public class DetalleFactura : BaseModel
    {
        public int NFactura { get; set; }
        public List<ProductoDetalle> ProductosDetalle { get; set; }
    }
}