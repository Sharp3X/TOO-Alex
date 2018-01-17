using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_dominio
{
    public abstract class Venta:IEquatable<Venta>
    {
        public Venta(string codigo,Dependiente dependiente)
        {
            //inicializaremos la fechaVenta con la fecha en el momento actual, y el atributo lineas como vacio
            this.codigo = codigo;
            this.fechaVenta = DateTime.Now;
            this.lineas = new List<LineaVenta>();
            this.dependiente = dependiente;
        }

        private Dependiente dependiente;
        private string codigo;
        private DateTime fechaVenta;
        private List<LineaVenta> lineas;
        
        public string Codigo
        {
            get
            {
                return this.codigo;
            }
            private set
            {
                this.codigo = value;
            }
        }

        public Dependiente Dependiente
        {
            get
            {
                return this.dependiente;
            }
            set
            {
                this.dependiente = value;
            }
        }

        public List<LineaVenta> Lineas
        {
            get
            {
                return this.lineas;
            }

            set
            {
                this.lineas = value;
            }
        }

        public DateTime FechaVenta
        {
            get
            {
                return this.fechaVenta;
            }
            
        }


        private double ImporteVenta
        {
            get
            {
                double i = 0;
                foreach (LineaVenta l in this.lineas)
                {
                    i += l.PrecioLineaVenta;
                }
                return i;
            }
        }

        public override string ToString()
        {
            return ("codigo: " + this.Codigo + " Dependiente(  " + this.Dependiente.NSS + ") Fecha: " + this.FechaVenta + " lineas: " + this.Lineas.ToString());
        }

        public bool Equals(Venta other)
        {
            return this.codigo == other.codigo;
        }
    }
}
