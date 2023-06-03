using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using Entidades;
using Datos;


namespace Negocio
{
    class ProvinciaNegocio
    {
        public TransactionResponse Escribir(Provincia prov, bool simple = true)
        {
            Conexion cn = new Conexion();
            string query = "";
            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (simple)
            {
                query = "INSERT INTO Provincia (Id_Provincia, DescripcionProvincia) VALUES (@ID, @descripcion)";
                dict.Add("@ID", prov.Id_Provincia1);
                dict.Add("@descripcion", prov.DescripcionProvincia1);
                
            }
            else { }
            int filasAfectadas = cn.EjecutarTransaccion(query, dict);
            var res = new TransactionResponse(cn, filasAfectadas);
            return res;
        }

        public TransactionResponse Eliminar(Provincia prov)
        {
            Conexion cn = new Conexion();
            string query = "DELETE FROM Provincia WHERE Id_Provincia = @id";
            Dictionary<string, object> dict = new Dictionary<string, object>() {
                { "@id", prov.Id_Provincia1}
            };
            int filasAfectadas = cn.EjecutarTransaccion(query, dict);
            return new TransactionResponse(cn, filasAfectadas);
        }


        public static DataSet ObtenerProvincia()
        {
            DataSet sucursales = new DataSet();
            Conexion cn = new Conexion();
            sucursales = cn.ObtenerDatos("SELECT * FROM [Provincia]");
            return sucursales;
        }

        public static DataSet FiltrarProvinciaID(Provincia prov)
        {
            DataSet sucursales = new DataSet();
            Conexion cn = new Conexion();
            Dictionary<string, object> dict = new Dictionary<string, object>() {
                { "id", prov.Id_Provincia1 }
            };
            sucursales = cn.ObtenerDatos("SELECT * FROM [Provincia]  WHERE Id_Sucursal = @id", dict);
            return sucursales;
        }
    }
}

