using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Entity;
using Data;

namespace BusinessLogic {
    public class ProvinciaLogic {
        public static class Columns {
            public static string Id { get { return "Id_Provincia"; } }
            public static string Descripcion { get { return "DescripcionProvincia"; } }
        }
        public static string Table { get { return "Provincia"; } }
        public ProvinciaLogic() {

        }
        public static Response ObtenerProvincias() {
            Connection cn = new Connection(Connection.Database.BDSucursales);
            return cn.Response.ErrorFound
                ? cn.Response
                : cn.FetchData(
                        query: $"SELECT [{Columns.Id}], [{Columns.Descripcion}] FROM [{Table}]"
                    );
        }
        public Response Escribir(Provincia obj) {
            Connection cn = new Connection(Connection.Database.BDSucursales);
            return cn.Response.ErrorFound
                ? cn.Response
                : cn.RunTransaction(
                        query: $"INSERT INTO [{Table}] " +
                               $"([{Columns.Id}], [{Columns.Descripcion}])" +
                               $"VALUES (@id, @descripcion)",
                        parameters: new Dictionary<string, object>() {
                            { "@id", obj.Id },
                            { "@descripcion", obj.Descripcion }
                        }
                    );
        }
    }
}
