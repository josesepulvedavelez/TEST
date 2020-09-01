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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Movimiento" en el código y en el archivo de configuración a la vez.
    public class Movimiento : IMovimiento
    {
        MovimientoBLL movimientoBLL;

        public int Transferir(MovimientoENT movimientoENT, bool exento)
        {
            movimientoBLL = new MovimientoBLL();

            return movimientoBLL.Transferir(movimientoENT, exento);
        }

        public List<MovimientoView> GetMovimientos(MovimientoView movimientoView)
        {
            MovimientoBLL movimientoBLL = new MovimientoBLL();

            return movimientoBLL.GetMovimientos(movimientoView);
        }
    }
}
