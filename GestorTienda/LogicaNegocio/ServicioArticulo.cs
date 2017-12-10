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
        public ServicioArticulo()
        {
            this.bd = BDArticulo.GetInstance();
        }
        public Articulo ObtenerInfoArticulo(Articulo pArticulo)
        {
            return bd.ObtenerArticulo(pArticulo);
        }

        public bool DarAltaArticulo(Articulo pArticulo)
        {
            return bd.AnadirArticulo(pArticulo);
        }

        public bool DarBajaArticulo(Articulo pArticulo)
        {
            return bd.EliminarArticulo(pArticulo);
        }

        public ICollection<Articulo> DatosCatalogoTienda()
        {
            return bd.Catalogo;
        }

        public ICollection<Articulo> ArticulosPorIva(tipoIva pIva)
        {

            return bd.ArticulosPorIva(pIva);
        }
    }
}
