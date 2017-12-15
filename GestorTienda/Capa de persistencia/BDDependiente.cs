using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_de_dominio;

namespace Capa_de_persistencia
{
    public class BDDependiente
    {
        private static BDDependiente instancia = null;
        private Dictionary<string, Dependiente> listaDependientes;
        private BDDependiente()
        {
            this.listaDependientes = new Dictionary<string, Dependiente>();
        }
        public static BDDependiente GetInstance()
        {
            if (instancia == null)
            {
                instancia = new BDDependiente();
            }
            return instancia;

        }

        public bool AnadirDependiente(Dependiente pDependiente)
        {
            if (!this.EstaDependiente(pDependiente))
            {
                this.listaDependientes.Add(pDependiente.NSS, pDependiente);
                return true;
            }
            return false;
        }
        public bool EliminarDependiente(Dependiente pDependiente)
        {
            if (this.EstaDependiente(pDependiente))
            {
                this.listaDependientes.Remove(pDependiente.NSS);
                return true;
            }
            return false;
        }



        public bool EstaDependiente(Dependiente pDependiente)
        {
            return this.listaDependientes.ContainsKey(pDependiente.NSS);
        }
    }
}
