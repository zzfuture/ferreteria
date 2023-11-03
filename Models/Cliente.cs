using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ferreteria.Models
{
    public class Cliente : BaseModel
    {
        public string Nombre { get; set; }
        public string Email { get; set; }
    }
}