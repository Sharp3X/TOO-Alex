using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_de_persistencia;
using Modelo_de_dominio;

namespace LogicaNegocio
{
    public class ServicioVenta
    {
        private BDVenta bd;
        public ServicioVenta()//el constructor crea una conexion con la base de datos.
        {
            this.bd = BDVenta.GetInstance();
            Venta v;
            v = new VentaContado("1001", new Dependiente("101", "Manuel", "Rodríguez"));
            AnadirLineaVenta(v, new Articulo("1", tipoIva.normal, 1), 2);
            this.bd.AnadirVenta(v);
            v = new VentaContado("1002", new Dependiente("101", "Manuel", "Rodríguez"));
            AnadirLineaVenta(v, new Articulo("1", tipoIva.normal, 1), 3);
            AnadirLineaVenta(v, new Articulo("2", tipoIva.normal, 10), 3);
            this.bd.AnadirVenta(v);
            v = new VentaContado("1003", new Dependiente("103", "Alex", "Martínez"));
            AnadirLineaVenta(v, new Articulo("5", tipoIva.reducido, 3), 2);
            this.bd.AnadirVenta(v);
            v = new VentaTarjeta("XXXX","1004", new Dependiente("106", "Oscar", "Ramírez"));
            AnadirLineaVenta(v, new Articulo("1", tipoIva.normal, 1), 2);
            AnadirLineaVenta(v, new Articulo("7", tipoIva.superReducido, 2), 6);
            AnadirLineaVenta(v, new Articulo("5", tipoIva.reducido, 3), 6);
            this.bd.AnadirVenta(v);
            v = new VentaTarjeta("YYYY", "1005", new Dependiente("102", "Pepe", "Pérez"));
            AnadirLineaVenta(v, new Articulo("6", tipoIva.superReducido, 6),2);
            this.bd.AnadirVenta(v);

            /* this.bd.AnadirArticulo(new Articulo("1", tipoIva.normal, 1));
             this.bd.AnadirArticulo(new Articulo("2", tipoIva.normal, 10));
             this.bd.AnadirArticulo(new Articulo("3", tipoIva.normal, 15));
             this.bd.AnadirArticulo(new Articulo("4", tipoIva.reducido, 2));
             this.bd.AnadirArticulo(new Articulo("5", tipoIva.reducido, 3));
             this.bd.AnadirArticulo(new Articulo("6", tipoIva.superReducido, 6));
             this.bd.AnadirArticulo(new Articulo("7", tipoIva.superReducido, 2));
             this.bd.AnadirDependiente(new Dependiente("101", "Manuel", "Rodríguez"));
             this.bd.AnadirDependiente(new Dependiente("102", "Pepe", "Pérez"));
             this.bd.AnadirDependiente(new Dependiente("103", "Alex", "Martínez"));
             this.bd.AnadirDependiente(new Dependiente("104", "David", "Madorrán"));
             this.bd.AnadirDependiente(new Dependiente("105", "Rodrigo", "Ortega"));
             this.bd.AnadirDependiente(new Dependiente("106", "Oscar", "Ramírez"));
             */
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

        public void AnadirLineaVenta(Venta pVenta, Articulo pArticulo, int pCantidad)// la venta parametro es a la que se le añade la linea de venta que sera creada con el articulo y la cantidad; por tanto el articulo debe ser comprobado que existe antes de añadirlo.
        {
            bool esta = false;
            foreach(LineaVenta l in pVenta.Lineas)
            {
                if (l.Articulo.Equals(pArticulo))
                {
                    esta = true;
                    l.Cantidad = l.Cantidad + pCantidad;
                }
            }
            if (!esta)
            {
            LineaVenta nLinea = new LineaVenta(pArticulo, pCantidad);
            pVenta.Lineas.Add(nLinea);
            }
        }

        public ICollection<Venta> DatosVentas()//devuelve una coleccion con todos las Ventas de la bd
        {
            return bd.ListaVentas;
        }

    }
}
