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
        private string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        private string Apellidos
        {
            get
            {
                return this.apellidos;
            }
            set
            {
                this.apellidos = value;
            }
        }

        public bool anadirVenta(Venta v)
        {
            if (!ventas.Contains(v))
            {
                this.ventas.Add(v);
                return true;
            }
            return false;
        }

        public bool Equals(Dependiente other)
        {
            return this.nss == other.nss;
        }
    }
}
