using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Entidades;
using Negocio;

namespace Servicios
{    
    [ServiceContract]
    public interface IClienteWCF
    {
        [OperationContract]
        int Loguear(ClienteENT clienteENT);

        [OperationContract]
        List<ClienteCuentaView> GetClienteCuenta(ClienteCuentaView clienteCuentaView);

        [OperationContract]
        ClienteENT GetClienteSesion(ClienteENT cliente);

        [OperationContract]
        List<CuentaENT> GetCuentas(string numero);
    }
}
