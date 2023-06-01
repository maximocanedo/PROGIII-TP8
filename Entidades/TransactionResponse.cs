using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Datos;

namespace Entidades {
    public class TransactionResponse {
        public int FilasAfectadas { get; set; }
        public string Mensaje { get; set; }
        public bool Estado { get; set; }
        public object Resultado { get; set; }
        public TransactionResponse(Conexion cn, int filasAfectadas = 0, object res = null) {
            Mensaje = cn.DetalleError;
            Estado = !cn.HuboError;
            FilasAfectadas = filasAfectadas;
            Resultado = res;
        }
    }
}
