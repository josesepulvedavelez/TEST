using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using Datos;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Data.SqlTypes;

namespace Negocio
{
    public class MovimientoBLL
    {
        MovimientoDAL movimientoDAL;
        List<MovimientoView> lst;
        int result;
        
        public int Transferir(MovimientoENT movimientoENT, bool exento)
        {
            movimientoDAL = new MovimientoDAL();

            if ((movimientoENT.Tipo == "transferencia" && exento == false))
            {
                movimientoENT.Gmf = (movimientoENT.Valor * 4) / 1000;
                result = movimientoDAL.Transferir(movimientoENT);
            }

            else if (movimientoENT.Tipo == "transferencia" && exento == true)
            {
                movimientoENT.Gmf = 0;
                result = movimientoDAL.Transferir(movimientoENT);
            }

            else if (movimientoENT.Tipo == "efectivo" && movimientoENT.Valor > 9600000)
            {
                movimientoENT.Gmf = (movimientoENT.Valor * 4) / 1000;
                result = movimientoDAL.TransferirEfectivo(movimientoENT);
            }

            else if (movimientoENT.Tipo == "efectivo")
            {
                movimientoENT.Gmf = 0;
                result = movimientoDAL.TransferirEfectivo(movimientoENT);
            }

            return result;
        }

        public List<MovimientoView> GetMovimientos(MovimientoView movimientoView)
        {
            MovimientoDAL movimientoDAL = new MovimientoDAL();
            lst = movimientoDAL.GetMovimientos(movimientoView);

            return lst;
        }
    }
}
