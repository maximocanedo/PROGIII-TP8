using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace TrabajoPractico5 {
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
    public class Provincia {
        public int id { get; set; }
        public string descripcion { get; set; }
        public Provincia(int id, string descripcion) {
            this.id = id;
            this.descripcion = descripcion;
        }
        public Provincia(int id) {
            this.id = id;
        }
        public Provincia() {
            this.id = -1;
            this.descripcion = "";
        }
        public static DataSet ObtenerProvincias() {
            DataSet provincias = new DataSet();
            Conexion cn = new Conexion();
            provincias = cn.ObtenerDatos("SELECT * FROM Provincia");
            return provincias;
        }

        public TransactionResponse Escribir() {
            Conexion cn = new Conexion();
            string query = "INSERT INTO Provincia (Id_Provincia, DescripcionProvincia) VALUES (@id, @descripcion)";
            Dictionary<string, object> prs = new Dictionary<string, object>() {
                {"@id", this.id },
                {"@descripcion", this.descripcion }
            };
            int filasAfectadas = cn.EjecutarTransaccion(query, prs);
            var res = new TransactionResponse(cn, filasAfectadas);
            return res;
        }

    }
}