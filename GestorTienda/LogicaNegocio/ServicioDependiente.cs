using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo_de_dominio;
using Capa_de_persistencia;


namespace LogicaNegocio
{
    public class ServicioDependiente
    {
        private BDDependiente bd;
        public ServicioDependiente()//el constructor crea una conexion con la base de datos.
        {
            this.bd = BDDependiente.GetInstance();
        }

        public bool DarAltaDependiente(Dependiente pDependiente)//el dependiente parametro no debe estar previamente en nuestra bd.
        {
            return bd.AnadirDependiente(pDependiente);
        }

        public bool DarBajaDependiente(Dependiente pDependiente)//el dependiente parametro debe estar previamente en nuestra bd.
        {
            return bd.EliminarDependiente(pDependiente);
        }

        public Dependiente ObtenerInfoDependiente(Dependiente pDependiente)//el dependiente pasado como parametro es un envoltorio para el codigo(lo unico que nos interesa), uso esta idea en todos los metodos con un dependiente como parámetro. como precondición el codigo de dicho articulo debe existir en la base de datos.
        {
            return bd.BuscarDependiente(pDependiente);
        }

        public bool AnadirVentaADependiente(Venta pVenta, Dependiente pDependiente)//primero usar AnadirVenta para guardarla en la bd y luego usar este metodo para asociarle la venta al dependiente
        {
            Dependiente d = this.bd.BuscarDependiente(pDependiente);//cogemos el dependiente al que queremos añadirle una venta
            if (d != null)
            {
            d.Ventas.Add(pVenta);
                return true;
            }
            return false;

        }

        public int VentasMes(int mes, Dependiente pDependiente)//el mes debe estar comprendido entre 1 y 12, del dependiente nos interesa su codigo.
        {
            Dependiente d = this.bd.BuscarDependiente(pDependiente);
            int contador = 0;
            foreach(Venta v in d.Ventas)
            {
                if (v.FechaVenta.Month == mes)
                {
                    contador++;
                }
            }
            return contador;
        }

        private void CalcularComision(Dependiente pDependiente, int numVentas)// el dependiente es real, este metodo es privado porque solo lo usare dentro de esta clase
        {
            pDependiente.Comision = numVentas * 0.05;//el 5% de las ventas le corresponderan al dependiente.
        }

        public ICollection<Dependiente> DatosDependientes()//devuelve una coleccion con todos los dependientes de la bd
        {
            return bd.ListaDependientes;
        }
    }
}
