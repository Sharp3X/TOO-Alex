using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modelo_de_dominio
{
    public enum tipoIva
    {
        normal=21,
        reducido=10,
        superReducido=4  //valores tipoIva.normal  tipoIva.reducido   tipoIva.superReducido  Se puede hacer un cast delante para obtener el valor
    }
}
