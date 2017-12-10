using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_dominio
{
    public class VentaContado : Venta
    {
        public VentaContado(string codigo, Dependiente dependiente) : base(codigo, dependiente)
        {
        }
    }
}
