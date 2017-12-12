using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_de_dominio;
using Capa_de_persistencia;

namespace LogicaNegocio
{
    public class ServicioArticulo
    {
        private BDArticulo bd;
        public ServicioArticulo()//el constructor crea una conexion con la base de datos.
        {
            this.bd = BDArticulo.GetInstance();
        }
        public Articulo ObtenerInfoArticulo(Articulo pArticulo)//el articulo pasado como parametro es un envoltorio para el codigo(lo unico que nos interesa). como precondicion el codigo de dicho articulo debe existir en la base de datos.
        {
            return bd.ObtenerArticulo(pArticulo);
        }

        public bool DarAltaArticulo(Articulo pArticulo)//el articulo parametro no debe estar previamente en nuestra bd.
        {
            return bd.AnadirArticulo(pArticulo);
        }

        public bool DarBajaArticulo(Articulo pArticulo)//el articulo parametro debe estar previamente en nuestra bd.
        {
            return bd.EliminarArticulo(pArticulo);
        }

        public ICollection<Articulo> DatosCatalogoTienda()//devuelve una coleccion con todos los articulos de la bd
        {
            return bd.Catalogo;
        }

        public List<Articulo> ArticulosPorIva(tipoIva pIva)//el iva debe ser un valor valido en nuestro sistema. devuelve una lista de articulos a los que se les aplica dicho iva.
        {

            ICollection<Articulo> listaIva = new List<Articulo>();
            foreach (Articulo x in this.bd.Catalogo)
            {
                if (x.Iva == pIva)
                {
                    listaIva.Add(x);
                }
            }
            return (List<Articulo>)listaIva;
        }
    }
}
