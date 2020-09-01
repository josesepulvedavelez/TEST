using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class MovimientoView
    {
        public int ClienteId { get; set; }
        public string Tipo { get; set; }
        public DateTime Fecha { get; set; }
        public double Valor { get; set; }
        public double Gmf { get; set; }
        public string CuentaOrigen { get; set; }
        public string CuentaDestino { get; set; }
    }
}
