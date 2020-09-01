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
    public class ClienteWCF : IClienteWCF
    {
        ClienteBLL clienteBLL;
        
        public int Loguear(ClienteENT clienteENT)
        {
            clienteBLL = new ClienteBLL();

            return clienteBLL.Loguear(clienteENT);
        }

        public List<ClienteCuentaView> GetClienteCuenta(ClienteCuentaView clienteCuentaView)
        {
            clienteBLL = new ClienteBLL();

            return clienteBLL.GetClienteCuenta(clienteCuentaView);
        }

        public ClienteENT GetClienteSesion(ClienteENT cliente)
        {
            clienteBLL = new ClienteBLL();

            return clienteBLL.GetClienteSesion(cliente);
        }

        public List<CuentaENT> GetCuentas(string numero)
        {
            clienteBLL = new ClienteBLL();

            return clienteBLL.GetCuentas(numero);
        }

    }
}
