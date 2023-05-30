using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using Data;

namespace BusinessLogic {
    public class SucursalLogic {
        public static class Columns {
            public static string Id { get { return "Id_Sucursal"; } }
            public static string Nombre { get { return "NombreSucursal"; } }
            public static string Descripcion { get { return "DescripcionSucursal"; } }
            public static string Horario { get { return "Id_HorarioSucursal"; } }
            public static string Provincia { get { return "Id_ProvinciaSucursal"; } }
            public static string Direccion { get { return "DireccionSucursal"; } }
            public static string Imagen { get { return "URL_Imagen_Sucursal"; } }
        }
        public static string Table { get { return "Sucursal"; } }
        public SucursalLogic() {
        }
        public static Response Escribir(Sucursal obj) {
            Connection cn = new Connection(Connection.Database.BDSucursales);
            return cn.Response.ErrorFound
                ? cn.Response
                : cn.RunTransaction(
                    query: $"INSERT INTO [{Table}] " +
                           $"([{Columns.Nombre}], " +
                           $"[{Columns.Descripcion}], " +
                           $"[{Columns.Provincia}], " +
                           $"[{Columns.Direccion}]) " +
                           $"VALUES (@nombre, @descripcion, @idProvincia, @direccion)",
                    parameters: new Dictionary<string, object> {
                        { "@nombre", obj.Nombre },
                        { "@descripcion", obj.Descripcion },
                        { "@idProvincia", obj.Provincia },
                        { "@direccion", obj.Direccion }
                    });
        }
        public Response Eliminar(Sucursal obj) {
            Connection cn = new Connection(Connection.Database.BDSucursales);
            return cn.Response.ErrorFound
                ? cn.Response
                : cn.RunTransaction(
                    query: $"DELETE FROM [{Table}] WHERE [{Columns.Id}] = @id",
                    parameters: new Dictionary<string, object> {
                        { "@id", obj.Id }
                    });
        }
        public static Response GetAll() {
            Connection con = new Connection(Connection.Database.BDSucursales);
            return con.Response.ErrorFound
                ? con.Response
                : con.FetchData(
                    query: $"SELECT [{Columns.Id}], " +
                           $"[{Columns.Nombre}], " +
                           $"[{Columns.Descripcion}], " +
                           $"[{Columns.Horario}], " +
                           $"[{Columns.Provincia}], " +
                           $"[{Columns.Direccion}], " +
                           $"REPLACE([{Columns.Imagen}], '~', '') as [{Columns.Imagen}] " +
                           $"FROM [{Table}]"
                    );
        }
        public static Response ObtenerSucursales() {
            Connection cn = new Connection(Connection.Database.BDSucursales);
            return cn.Response.ErrorFound
                ? cn.Response
                : cn.FetchData(
                        query: $"SELECT " +
                               $"[{Columns.Id}] as [ID], " +
                               $"[{Columns.Nombre}] as [Nombre], " +
                               $"[{Columns.Descripcion}] as [Descripción], " +
                               $"[{ProvinciaLogic.Table}].[{ProvinciaLogic.Columns.Descripcion}] as [Provincia], " +
                               $"[{Columns.Direccion}] as [Dirección] " +
                               $"FROM [{Table}] INNER JOIN [{ProvinciaLogic.Table}] " +
                               $"ON [{Table}].[{Columns.Provincia}] = [{ProvinciaLogic.Table}].[{ProvinciaLogic.Columns.Id}]"
                           );
        }
        public static Response FiltrarSucursalesPorID(int id) {
            Connection cn = new Connection(Connection.Database.BDSucursales);
            return cn.Response.ErrorFound
                ? cn.Response
                : cn.FetchData(
                        query: $"SELECT " +
                               $"[{Columns.Id}] as [ID], " +
                               $"[{Columns.Nombre}] as [Nombre], " +
                               $"[{Columns.Descripcion}] as [Descripción], " +
                               $"[{ProvinciaLogic.Table}].[{ProvinciaLogic.Columns.Descripcion}] as [Provincia], " +
                               $"[{Columns.Direccion}] as [Dirección] " +
                               $"FROM [{Table}] INNER JOIN [{ProvinciaLogic.Table}] " +
                               $"ON [{Table}].[{Columns.Provincia}] = [{ProvinciaLogic.Table}].[{ProvinciaLogic.Columns.Id}] " +
                               $"WHERE [{Columns.Id}] = @id",
                        parameters: new Dictionary<string, object>() {
                            { "@id", id }
                        });
        }
        public static Response FilterByProvinceId(int provinceId) {
            Connection con = new Connection(Connection.Database.BDSucursales);
            return con.Response.ErrorFound
                ? con.Response
                : con.FetchData(
                    query: $"SELECT [{Columns.Id}], " +
                           $"[{Columns.Nombre}], " +
                           $"[{Columns.Descripcion}], " +
                           $"[{Columns.Horario}], " +
                           $"[{Columns.Provincia}], " +
                           $"[{Columns.Direccion}], " +
                           $"REPLACE([{Columns.Imagen}], '~', '') as [{Columns.Imagen}] " +
                           $"FROM [{Table}] " +
                           $"WHERE [{Columns.Provincia}] = @id",
                    parameters: new Dictionary<string, object> {
                        { "@id", provinceId }
                    });
        }
    }
}
