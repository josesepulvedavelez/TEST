using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MovimientoENT
    {
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public double Gmf { get; set; }
        public int CuentaOrigen { get; set; }
        public int? CuentaDestino { get; set; }
    }
}
