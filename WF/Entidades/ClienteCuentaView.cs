using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClienteCuentaView
    {        
        public string Nombres { get; set; }        
        public string Usuario { get; set; }
        public int ClienteId { get; set; }
        public string Banco { get; set; }
        public int BancoId { get; set; }
        public string Numero { get; set; }
        public string Tipo { get; set; }
        public double Saldo { get; set; }
        public int CuentaId { get; set; }
    }
}
