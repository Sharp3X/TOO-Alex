using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_dominio
{
    public class LineaVenta
    {
        private Articulo articulo;
        private int cantidad;

        public LineaVenta(Articulo articulo,int cantidad)
        {
            this.articulo = articulo;
            this.cantidad = cantidad;
        }
        public double PrecioLineaVenta
        {
            get
            {
                return this.articulo.PrecioVenta * cantidad;
            }
        }
    }
}
