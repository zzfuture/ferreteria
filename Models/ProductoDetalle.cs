using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Models
{
    public class ProductoDetalle : BaseModel
    {
        public int Cantidad { get; set; }
        public int Valor { get; set; }
    }
}