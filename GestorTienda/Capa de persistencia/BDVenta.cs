using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_de_dominio;

namespace Capa_de_persistencia
{
    public class BDVenta
    {
        private static BDVenta instancia = null;
        private Dictionary<string, Venta> listaVentas;
        private BDVenta()
        {
            this.listaVentas = new Dictionary<string, Venta>();
        }
        public static BDVenta GetInstance()
        {
            if (instancia == null)
            {
                instancia = new BDVenta();
            }
            return instancia;

        }

        public ICollection<Venta> ListaVentas
        {
            get
            {
                return this.listaVentas.Values;
            }
        }

        public bool AnadirVenta(Venta pVenta)
        {
            if (!this.EstaVenta(pVenta))
            {
                this.listaVentas.Add(pVenta.Codigo, pVenta);
                return true;
            }
            return false;
        }
        public bool EliminarVenta(Venta pVenta)
        {
            if (this.EstaVenta(pVenta))
            {
                this.listaVentas.Remove(pVenta.Codigo);
                return true;
            }
            return false;
        }



        public bool EstaVenta(Venta pVenta)
        {
            return this.listaVentas.ContainsKey(pVenta.Codigo);
        }
    }
}
