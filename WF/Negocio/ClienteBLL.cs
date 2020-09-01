using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;

namespace Negocio
{
    public class ClienteBLL
    {
        int result;
        ClienteDAL clienteDAL;
        List<ClienteCuentaView> lst;
        ClienteENT clienteSesion;
        List<CuentaENT> lstCuentas;

        public int Loguear(ClienteENT clienteENT)
        {
            clienteDAL = new ClienteDAL();
            result = clienteDAL.Loguear(clienteENT);

            return result;
        }

        public List<ClienteCuentaView> GetClienteCuenta(ClienteCuentaView clienteCuentaView)
        {
            clienteDAL = new ClienteDAL();
            lst = clienteDAL.GetClienteCuenta(clienteCuentaView);

            return lst;
        }

        public ClienteENT GetClienteSesion(ClienteENT cliente)
        {            
            clienteDAL = new ClienteDAL();
            clienteSesion = new ClienteENT();

            clienteSesion = clienteDAL.GetClienteSesion(cliente);

            return clienteSesion;
        }

        public List<CuentaENT> GetCuentas(string numero)
        {
            clienteDAL = new ClienteDAL();
            lstCuentas = clienteDAL.GetCuentas(numero);

            return lstCuentas;
        }
    }
}
