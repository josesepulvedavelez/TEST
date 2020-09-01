using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class ClienteENT
    {
        public string Nombres { get; set; }
        public string Usuario { get; set; }
        public string Contraseña { get; set; }
        public bool Exento { get; set; }
        public int ClienteId { get; set; }
    }
}
