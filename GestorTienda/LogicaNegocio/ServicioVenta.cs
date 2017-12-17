using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_persistencia;
using Modelo_de_dominio;

namespace LogicaNegocio
{
    class ServicioVenta
    {
        private BDVenta bd;
        public ServicioVenta()//el constructor crea una conexion con la base de datos.
        {
            this.bd = BDVenta.GetInstance();
        }

        public bool DarAltaVenta(Venta pVenta)//la venta parametro no debe estar previamente en nuestra bd.
        {
            return bd.AnadirVenta(pVenta);
        }

        public bool DarBajaVenta(Venta pVenta)//el Venta parametro debe estar previamente en nuestra bd.
        {
            return bd.EliminarVenta(pVenta);
        }

        public Venta ObtenerInfoVenta(Venta pVenta)//la Venta pasado como parametro es un envoltorio para el codigo(lo unico que nos interesa), uso esta idea en todos los metodos con una Venta como parámetro. como precondición el codigo de dicho articulo debe existir en la base de datos.
        {
            return bd.BuscarVenta(pVenta);
        }

        public ICollection<Venta> DatosVentas()//devuelve una coleccion con todos las Ventas de la bd
        {
            return bd.ListaVentas;
        }

    }
}
