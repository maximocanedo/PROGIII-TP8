using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;

namespace TrabajoPractico5 {
    public class Sucursal {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public int horario { get; set; }
        public Provincia provincia { get; set; }
        public string direccion { get; set; }
        public string imagen { get; set; }
        public Sucursal(int id, string nombre, string descripcion, int horario, Provincia provincia, string direccion, string imagen) {
            this.id = id;
            this.nombre = nombre;
            this.descripcion = descripcion;
            this.horario = horario;
            this.provincia = provincia;
            this.direccion = direccion;
            this.imagen = imagen;
        }
        public Sucursal() {
            this.id = -1;
        }
        public TransactionResponse Escribir(bool simple = true) {
            Conexion cn = new Conexion();
            string query = "";
            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (simple) {
                query = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) VALUES (@nombre, @descripcion, @idProvincia, @direccion)";
                dict.Add("@nombre", this.nombre);
                dict.Add("@descripcion", this.descripcion);
                dict.Add("@idProvincia", this.provincia.id);
                dict.Add("@direccion", this.direccion);
            }
            else { }
            int filasAfectadas = cn.EjecutarTransaccion(query, dict);
            var res = new TransactionResponse(cn, filasAfectadas);
            return res;
        }
        public TransactionResponse Eliminar() {
            Conexion cn = new Conexion();
            string query = "DELETE FROM Sucursal WHERE Id_Sucursal = @id";
            Dictionary<string, object> dict = new Dictionary<string, object>() {
                { "@id", this.id }
            };
            int filasAfectadas = cn.EjecutarTransaccion(query, dict);
            return new TransactionResponse(cn, filasAfectadas);
        }

        public static DataSet ObtenerSucursales() {
            DataSet sucursales = new DataSet();
            Conexion cn = new Conexion();
            sucursales = cn.ObtenerDatos("SELECT [Id_Sucursal] as ID,[NombreSucursal] as Nombre,[DescripcionSucursal] as [Descripción],Provincia.DescripcionProvincia as [Provincia],[DireccionSucursal] as [Dirección]FROM [Sucursal] INNER JOIN dbo.Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia");
            return sucursales;
        }
        public static DataSet FiltrarSucursalesPorID(int id) {
            DataSet sucursales = new DataSet();
            Conexion cn = new Conexion();
            Dictionary<string, object> dict = new Dictionary<string, object>() {
                { "id", id }
            };
            sucursales = cn.ObtenerDatos("SELECT [Id_Sucursal] as ID,[NombreSucursal] as Nombre,[DescripcionSucursal] as [Descripción],Provincia.DescripcionProvincia as [Provincia],[DireccionSucursal] as [Dirección]FROM [Sucursal] INNER JOIN dbo.Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia WHERE Id_Sucursal = @id", dict);
            return sucursales;
        }


    }
}