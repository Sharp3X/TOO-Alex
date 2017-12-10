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
        
        private string Codigo
        {
            get
            {
                return this.codigo;
            }
            set
            {
                this.codigo = value;
            }
        }

        private DateTime FechaVenta
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

        public bool Equals(Venta other)
        {
            return this.codigo == other.codigo;
        }
    }
}
