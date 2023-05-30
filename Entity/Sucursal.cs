using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
    public class Sucursal {
        private string _n, _d, _ds, _u;
        public int Id { get; set; }
        public string Nombre { get { return _n; } set { _n = value.Length > 100 ? value.Substring(0, 100) : value; } }
        public string Descripcion { get { return _d; } set { _d = value.Length > 100 ? value.Substring(0, 100) : value; } }
        public int Horario { get; set; }
        public int Provincia { get; set; }
        public string Direccion { get { return _ds; } set { _ds = value.Length > 100 ? value.Substring(0, 100) : value; } }
        public string Imagen { get { return _u; } set { _u = value.Length > 100 ? value.Substring(0, 100) : value; } }
        public Sucursal() {

        }
        
    }
}
