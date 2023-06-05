using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Sucursal
    {
        private int ID;
        private String Nombre;
        private String Descripcion;
        private int Provincia;
        private String Direccion;

        public Sucursal()
        {

        }

        public int ID1 { get => ID; set => ID = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int Provincia1 { get => Provincia; set => Provincia = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
    }
}
