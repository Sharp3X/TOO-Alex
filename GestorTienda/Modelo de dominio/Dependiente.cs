using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_dominio
{
    public class Dependiente:IEquatable<Dependiente>
    {
        private string nss;
        private string nombre;
        private string apellidos;
        private double comision; //no se ni que es hulio
        private List<Venta> ventas;

        public Dependiente(string nss,string nombre,string apellidos)
        {
            this.nss = nss;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.ventas = new List<Venta>();
        }
        public string NSS
        {
            get
            {
                return this.nss;
            }
            private set
            {
                this.nss = value;
            }
        }
        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            private set
            {
                this.nombre = value;
            }
        }
        public string Apellidos
        {
            get
            {
                return this.apellidos;
            }
            private set
            {
                this.apellidos = value;
            }
        }

        public double Comision
        {
            get
            {
                return this.comision;
            }

            set
            {
                this.comision = value;
            }
        }

        public List<Venta> Ventas
        {
            get
            {
                return this.ventas;
            }
        }

        public string ToString()
        {
            return ("Nombre: " + this.Nombre + " Apellidos: " + this.Apellidos + " nss: " + this.NSS + " ventas: " + this.Ventas.ToString());
        }

        public bool Equals(Dependiente other)
        {
            return this.nss == other.nss;
        }
    }
}
