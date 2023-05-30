using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity {
    public class Provincia {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public Provincia(int id, string descripcion) {
            this.Id = id;
            this.Descripcion = descripcion;
        }
        public Provincia(int id) {
            this.Id = id;
        }
        public Provincia() {
            this.Id = -1;
            this.Descripcion = "";
        }
    }
}
