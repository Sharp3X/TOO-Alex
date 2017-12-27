using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_dominio
{
    public class VentaTarjeta : Venta
    {
        private string numTarjeta;
        public VentaTarjeta(string numTarjeta, string codigo, Dependiente dependiente) : base(codigo, dependiente)
        {
            this.numTarjeta = numTarjeta;
        }

        public string NumTarjeta
        {
            get
            {
                return this.numTarjeta;
            }
            set
            {
                this.numTarjeta = value;
            }
        }
        public string ToString()
        {
            return (base.ToString() + " numeroTarjeta: " + this.NumTarjeta);
        }
    }
}
