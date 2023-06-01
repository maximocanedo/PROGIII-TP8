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
    class SucursalNegocio
    {
        public SucursalNegocio()
        {

        }


        public TransactionResponse Escribir(bool simple = true, Sucursal suc)
        {
            Conexion cn = new Conexion();
            string query = "";
            Dictionary<string, object> dict = new Dictionary<string, object>();
            if (simple)
            {
                query = "INSERT INTO Sucursal (NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) VALUES (@nombre, @descripcion, @idProvincia, @direccion)";
                dict.Add("@nombre", suc.Nombre1);
                dict.Add("@descripcion", suc.Descripcion1);
                dict.Add("@idProvincia", suc.IDProvincia1);
                dict.Add("@direccion", suc.Direccion1);
            }
            else { }
            int filasAfectadas = cn.EjecutarTransaccion(query, dict);
            var res = new TransactionResponse(cn, filasAfectadas);
            return res;
        }

        public TransactionResponse Eliminar(Sucursal suc)
        {
            Conexion cn = new Conexion();
            string query = "DELETE FROM Sucursal WHERE Id_Sucursal = @id";
            Dictionary<string, object> dict = new Dictionary<string, object>() {
                { "@id", suc.Id1 }
            };
            int filasAfectadas = cn.EjecutarTransaccion(query, dict);
            return new TransactionResponse(cn, filasAfectadas);
        }


        public static DataSet ObtenerSucursales()
        {
            DataSet sucursales = new DataSet();
            Conexion cn = new Conexion();
            sucursales = cn.ObtenerDatos("SELECT [Id_Sucursal] as ID,[NombreSucursal] as Nombre,[DescripcionSucursal] as [Descripción],Provincia.DescripcionProvincia as [Provincia],[DireccionSucursal] as [Dirección]FROM [Sucursal] INNER JOIN dbo.Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia");
            return sucursales;
        }

        public static DataSet FiltrarSucursalesPorID(Sucursal suc)
        {
            DataSet sucursales = new DataSet();
            Conexion cn = new Conexion();
            Dictionary<string, object> dict = new Dictionary<string, object>() {
                { "id", suc.Id1 }
            };
            sucursales = cn.ObtenerDatos("SELECT [Id_Sucursal] as ID,[NombreSucursal] as Nombre,[DescripcionSucursal] as [Descripción],Provincia.DescripcionProvincia as [Provincia],[DireccionSucursal] as [Dirección]FROM [Sucursal] INNER JOIN dbo.Provincia ON Sucursal.Id_ProvinciaSucursal = Provincia.Id_Provincia WHERE Id_Sucursal = @id", dict);
            return sucursales;
        }
    }
}
