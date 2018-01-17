using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_dominio
{
    public class Articulo : IEquatable<Articulo>
    {
        private string codigo;
        private tipoIva iva;
        private double precioCoste;
        private string descripcion;
        public string Codigo
        {
            get
            {
                return this.codigo;
            }
        }

        public tipoIva Iva
        {
            get
            {
                return this.iva;
            }
        }

        public Articulo(string codigo, tipoIva iva, double pCoste)
        {
            this.codigo = codigo;
            this.iva = iva;
            this.precioCoste = pCoste;
            this.descripcion ="el codigo de articulo es: " + this.Codigo + ". el iva que tiene aplicado es: " + this.Iva + "% y su precio de venta es: " + this.PrecioVenta;
        }

        public string Descripcion
        {
            get
            {
                return this.descripcion;
            }
            set
            {
                this.descripcion = value;
            }
        }

        

        public double PrecioVenta {
            get
            {
                
                return this.precioCoste * (1 + (((int)(this.iva))*1.0 / 100));
            }
        }

        public override string ToString()
        {
            return ("codigo: " + this.Codigo + " precio: " + this.PrecioVenta);
        }

        public bool Equals(Articulo other)
        {
            return (this.codigo == other.codigo);           
        }
    }
}
