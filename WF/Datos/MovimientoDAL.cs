using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Entidades;
using System.Data.SqlClient;

namespace Datos
{    
    public class MovimientoDAL
    {
        TransactionScope transactionScope;
        SqlConnection conexion;
        SqlCommand comando;
        SqlDataReader lector;
        int result;

        string sqlMovimiento = "INSERT INTO Movimiento(Tipo, Fecha, Valor, Gmf, CuentaOrigen, CuentaDestino) VALUES(@Tipo, @Fecha, @Valor, @Gmf, @CuentaOrigen, @CuentaDestino)";
        string sqlCuentaOrigen = "UPDATE Cuenta SET Saldo=Saldo-@Valor WHERE CuentaId=@CuentaId";
        string sqlCuentaDestino = "UPDATE Cuenta SET Saldo=(Saldo+@Valor)-@Gmf WHERE CuentaId=@CuentaId";

        string sqlMovimientoView = "SELECT * FROM MovimientoView WHERE ClienteId=@ClienteId";

        public int Transferir(MovimientoENT movimientoENT)
        {
            using (transactionScope = new TransactionScope())
            {
                using (conexion = new SqlConnection(Conexion.Conectar()))
                {
                    conexion.Open();

                    comando = new SqlCommand(sqlMovimiento, conexion);
                    comando.Parameters.AddWithValue("@Tipo", movimientoENT.Tipo);
                    comando.Parameters.AddWithValue("@Fecha", movimientoENT.Fecha);
                    comando.Parameters.AddWithValue("@Valor", movimientoENT.Valor);
                    comando.Parameters.AddWithValue("@Gmf", movimientoENT.Gmf);
                    comando.Parameters.AddWithValue("@CuentaOrigen", movimientoENT.CuentaOrigen);
                    comando.Parameters.AddWithValue("@CuentaDestino", movimientoENT.CuentaDestino);
                    result = comando.ExecuteNonQuery();

                    comando = new SqlCommand(sqlCuentaOrigen, conexion);                    
                    comando.Parameters.AddWithValue("@Valor", movimientoENT.Valor);
                    comando.Parameters.AddWithValue("@CuentaId", movimientoENT.CuentaOrigen);
                    result =  comando.ExecuteNonQuery();

                    comando = new SqlCommand(sqlCuentaDestino, conexion);
                    comando.Parameters.AddWithValue("@Valor", movimientoENT.Valor);
                    comando.Parameters.AddWithValue("@CuentaId", movimientoENT.CuentaDestino);
                    comando.Parameters.AddWithValue("@Gmf", movimientoENT.Gmf);
                    result = comando.ExecuteNonQuery();

                    conexion.Close();
                }

                transactionScope.Complete();
            }
            return result;
        }

        string sqlMovimientoEfectivo = "INSERT INTO Movimiento(Tipo, Fecha, Valor, Gmf, CuentaOrigen) VALUES(@Tipo, @Fecha, @Valor, @Gmf, @CuentaOrigen)";
        public int TransferirEfectivo(MovimientoENT movimientoENT)
        {
            using (transactionScope = new TransactionScope())
            {
                using (conexion = new SqlConnection(Conexion.Conectar()))
                {
                    conexion.Open();

                    comando = new SqlCommand(sqlMovimientoEfectivo, conexion);
                    comando.Parameters.AddWithValue("@Tipo", movimientoENT.Tipo);
                    comando.Parameters.AddWithValue("@Fecha", movimientoENT.Fecha);
                    comando.Parameters.AddWithValue("@Valor", movimientoENT.Valor);
                    comando.Parameters.AddWithValue("@Gmf", movimientoENT.Gmf);
                    comando.Parameters.AddWithValue("@CuentaOrigen", movimientoENT.CuentaOrigen);                    
                    result = comando.ExecuteNonQuery();

                    comando = new SqlCommand(sqlCuentaOrigen, conexion);
                    comando.Parameters.AddWithValue("@Valor", movimientoENT.Valor);
                    comando.Parameters.AddWithValue("@CuentaId", movimientoENT.CuentaOrigen);
                    result = comando.ExecuteNonQuery();

                    conexion.Close();
                }

                transactionScope.Complete();
            }
            return result;
        }

        public List<MovimientoView> GetMovimientos(MovimientoView movimientoView)
        {
            List<MovimientoView> lst = new List<MovimientoView>();

            using (conexion = new SqlConnection(Conexion.Conectar()))
            {
                conexion.Open();

                using (comando = new SqlCommand(sqlMovimientoView, conexion))
                {
                    comando.Parameters.AddWithValue("@ClienteId", movimientoView.ClienteId);

                    lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        MovimientoView mv = new MovimientoView()
                        {
                            ClienteId = Convert.ToInt32(lector["ClienteId"]),
                            Tipo = Convert.ToString(lector["Tipo"]),
                            Fecha = Convert.ToDateTime(lector["Fecha"]),
                            Valor = Convert.ToDouble(lector["Valor"]),
                            Gmf = Convert.ToDouble(lector["Gmf"]),
                            CuentaOrigen = Convert.ToString(lector["CuentaOrigen"]),
                            CuentaDestino = Convert.ToString(lector["CuentaDestino"])
                        };

                        lst.Add(mv);
                    }
                }
            }
            return lst;
        }

    }
}
