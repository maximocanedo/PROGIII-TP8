using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class DaoProvincia
    {
        AccesoDatos ad = new AccesoDatos();

        public Provincia getProvincia(Provincia prov)
        {
            DataTable tabla = ad.ObtenerTabla("Provincia", "SELECT * FROM Provincia WHERE Id_Provincia = " + prov.getID());
            prov.setID(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            prov.setDescripcion(tabla.Rows[0][1].ToString());
            return prov;
        }

        public Boolean existeProvincia(Provincia prov)
        {
            String consulta = "SELECT * FROM Provincia WHERE Id_Provincia = " + prov.getID();
            return ad.existe(consulta);
        }

        public DataTable getTablaProvincias()
        {
            DataTable tabla = ad.ObtenerTabla("Provincia", "SELECT * FROM Provincia");
            return tabla;
        }

        /*
         CÓDIGO DE REFERENCIA:
        public DataTable getTablaCategorias()
        {
           // List<Categoria> lista = new List<Categoria>();
            DataTable tabla = ds.ObtenerTabla("Categoria", "Select * from categorías");
            return tabla;
        }

        public int eliminarCategoria(Categoria cat)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCategoriaEliminar(ref comando, cat);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spEliminarCategoria");
        }


        public int agregarCategoria(Categoria cat)
        {
           
            cat.setIdCategoria(ds.ObtenerMaximo("SELECT max(idCategoría) FROM Categorías")+1);
            SqlCommand comando = new SqlCommand();
            ArmarParametrosCategoriaAgregar(ref comando, cat);
            return ds.EjecutarProcedimientoAlmacenado(comando, "spAgregarCategoria");
        }

        private void ArmarParametrosCategoriaEliminar(ref SqlCommand Comando, Categoria cat)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
            SqlParametros.Value = cat.getIdCategoria();
        }

        private void ArmarParametrosCategoriaAgregar(ref SqlCommand Comando, Categoria cat)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDCATEGORIA", SqlDbType.Int);
            SqlParametros.Value = cat.getIdCategoria();
            SqlParametros = Comando.Parameters.Add("@NOMBRECAT", SqlDbType.VarChar);
            SqlParametros.Value = cat.getNombreCategoria();
        }
        */

        /*
        CREATE PROCEDURE[dbo].[spEliminarCategoria]
        (
               @IDCATEGORIA INT
               )
               AS
        DELETE Categorías WHERE IdCategoría = @IDCATEGORIA
        RETURN
        */

        /*
       CREATE PROCEDURE[dbo].[spAgregarCategoria]
        (
        @IDCATEGORIA INT,
        @NOMBRECAT NVARCHAR(15)
        )
        AS
        INSERT INTO CATEGORÍAS(IdCategoría,NombreCategoría) VALUES(@IDCATEGORIA,@NOMBRECAT)
        RETURN
        */
    }
}
