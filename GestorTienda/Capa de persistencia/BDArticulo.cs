using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_de_dominio;

namespace Capa_de_persistencia
{
    public class BDArticulo
    {
        private static BDArticulo instancia = null;
        private Dictionary<string, Articulo> catalogo;
        private BDArticulo()
        {
            this.catalogo = new Dictionary<string, Articulo>();
        }
        public static BDArticulo GetInstance()
        {
            if(instancia== null)
            {
                instancia = new BDArticulo();
            }
            return instancia;

        }

        public ICollection<Articulo> Catalogo
        {
            get
            {
                return this.catalogo.Values;
            }
        }
        public bool AnadirArticulo(Articulo pArticulo)
        {
            if (!this.EstaArticulo(pArticulo))
            {
                this.catalogo.Add(pArticulo.Codigo, pArticulo);
                return true;
            }
            return false;
        }
        public bool EliminarArticulo(Articulo pArticulo)
        {
            if (this.EstaArticulo(pArticulo))
            {
                this.catalogo.Remove(pArticulo.Codigo);
                return true;
            }
            return false;
        }



        public bool EstaArticulo(Articulo pArticulo)
        {
            return this.catalogo.ContainsKey(pArticulo.Codigo);
        }
        public Articulo BuscarArticulo(Articulo pArticulo)
        {
            if (this.EstaArticulo(pArticulo))
            {
                foreach(Articulo x in this.Catalogo)
                {
                    if (pArticulo.Equals(x))
                    {
                        return x;
                    }
                }
            }
            return null;
        }

    }
}
