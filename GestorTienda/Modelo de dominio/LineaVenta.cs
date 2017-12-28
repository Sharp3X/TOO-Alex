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

        public Articulo Articulo
        {
            get
            {
                return this.articulo;
            }
        }

        public int Cantidad
        {
            get
            {
                return this.cantidad;
            }
            set
            {
                this.cantidad = value;
            }
        }
        public double PrecioLineaVenta
        {
            get
            {
                return this.articulo.PrecioVenta * cantidad;
            }
        }

        public string ToString()
        {
            return (this.articulo.ToString() + " x " + this.cantidad);
        }
    }
}
