using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Provincia
    {
        private int ID;
        private String Descripcion;

        public Provincia()
        {

        }

        // public int ID1 { get => ID; set => ID = value; }
        // public string Descripcion1 { get => Descripcion; set => Descripcion = value; }

        public int getID() { return ID; }
        public String getDescripcion() { return Descripcion; }

        public void setID(int id) { ID = id; }
        public void setDescripcion(String desc) { Descripcion = desc; }
    }
}
