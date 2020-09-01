using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entidades;

namespace Servicios
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IMovimiento" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IMovimiento
    {
        [OperationContract]
        int Transferir(MovimientoENT movimientoENT, bool exento);

        [OperationContract]
        List<MovimientoView> GetMovimientos(MovimientoView movimientoView);
    }
}
