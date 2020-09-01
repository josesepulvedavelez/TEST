using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Entidades;

namespace Datos
{
    public class ClienteDAL
    {
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        int result;
        
        string sqlLogin = "SELECT COUNT(*) FROM Cliente WHERE Usuario=@Usuario AND Contraseña=@Contraseña";
        string sqlClienteCuenta = "SELECT Nombres, Usuario, ClienteId, Banco, BancoId, Numero, Tipo, Saldo, CuentaId FROM ClienteCuentaView WHERE Usuario=@Usuario";
        string sqlClienteSesion = "SELECT Nombres, Exento, ClienteId FROM Cliente WHERE Usuario=@Usuario";

        public int Loguear(ClienteENT clienteENT)
        {
            using (conexion = new SqlConnection(Conexion.Conectar()))
            {
                using (comando = new SqlCommand(sqlLogin, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", clienteENT.Usuario);
                    comando.Parameters.AddWithValue("@Contraseña", clienteENT.Contraseña);

                    conexion.Open();
                    result = Convert.ToInt16(comando.ExecuteScalar());
                    conexion.Close();
                }
            }

            if (result == 1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        public List<ClienteCuentaView> GetClienteCuenta(ClienteCuentaView clienteCuentaView)
        {
            List<ClienteCuentaView> lst = new List<ClienteCuentaView>();

            using (conexion = new SqlConnection(Conexion.Conectar()))
            {
                conexion.Open();

                using (comando = new SqlCommand(sqlClienteCuenta, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", clienteCuentaView.Usuario);

                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        ClienteCuentaView ccv = new ClienteCuentaView()
                        {
                            Nombres = Convert.ToString(lector["Nombres"]),
                            Usuario = Convert.ToString(lector["Usuario"]),
                            ClienteId = Convert.ToInt32(lector["ClienteId"]),
                            Banco = Convert.ToString(lector["Banco"]),
                            BancoId = Convert.ToInt32(lector["BancoId"]),
                            Numero = Convert.ToString(lector["Numero"]),
                            Tipo = Convert.ToString(lector["Tipo"]),
                            Saldo = Convert.ToDouble(lector["Saldo"]),
                            CuentaId = Convert.ToInt32(lector["CuentaId"])
                        };
                        lst.Add(ccv);
                    }
                }
            }
            return lst;
        }

        public ClienteENT GetClienteSesion(ClienteENT cliente)
        {
            ClienteENT clienteENT = new ClienteENT();

            using (conexion = new SqlConnection(Conexion.Conectar()))
            {
                conexion.Open();

                using (comando = new SqlCommand(sqlClienteSesion, conexion))
                {
                    comando.Parameters.AddWithValue("@Usuario", cliente.Usuario);

                    lector = comando.ExecuteReader();

                    if (lector.Read())
                    {
                        clienteENT.ClienteId = Convert.ToInt32(lector["ClienteId"]);
                        clienteENT.Nombres = Convert.ToString(lector["Nombres"]);
                        clienteENT.Exento = Convert.ToBoolean(lector["Exento"]);
                    }
                }
            }

            return clienteENT;
        }

        public List<CuentaENT> GetCuentas(string numero)
        {
            List<CuentaENT> lst = new List<CuentaENT>();

            using (conexion = new SqlConnection(Conexion.Conectar()))
            {
                conexion.Open();

                using (comando = new SqlCommand("SELECT Numero, CuentaId FROM Cuenta WHERE Numero <> @Numero", conexion))
                {
                    comando.Parameters.AddWithValue("@Numero", numero);

                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        CuentaENT cuentaENT = new CuentaENT()
                        {
                            Numero = Convert.ToString(lector["Numero"]),
                            CuentaId = Convert.ToInt32(lector["CuentaId"])
                        };
                        lst.Add(cuentaENT);
                    }
                }
            }
            return lst;
        }

    }
}
