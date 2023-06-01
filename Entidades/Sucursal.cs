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
        private int IDProvincia;
        private String Direccion;

        //Constructor
        public Sucursal()
        {

        }
        //Gets y Sets
        public int Id1 { get => ID; set => ID = value; }
        public string Nombre1 { get => Nombre; set => Nombre = value; }
        public string Descripcion1 { get => Descripcion; set => Descripcion = value; }
        public int IDProvincia1 { get => IDProvincia; set => IDProvincia = value; }
        public string Direccion1 { get => Direccion; set => Direccion = value; }
    }
}