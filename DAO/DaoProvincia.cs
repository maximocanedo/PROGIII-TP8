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

        private void ArmarParametrosProvinciaEliminar(ref SqlCommand Comando, Provincia prov)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDPROVINCIA", SqlDbType.Int);
            SqlParametros.Value = prov.getID();
        }

        public int eliminarProvincia(Provincia prov)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProvinciaEliminar(ref comando, prov);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spEliminarProvincia");
        }

        private void ArmarParametrosProvinciaAgregar(ref SqlCommand Comando, Provincia prov)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDPROVINCIA", SqlDbType.Int);
            SqlParametros.Value = prov.getID();
            SqlParametros = Comando.Parameters.Add("@DESCRIPCIONPROV", SqlDbType.VarChar);
            SqlParametros.Value = prov.getDescripcion();
        }

        public int agregarProvincia(Provincia prov)
        {
            prov.setID(ad.ObtenerMaximo("SELECT MAX(Id_Provincia) FROM Provincia") + 1);
            SqlCommand comando = new SqlCommand();
            ArmarParametrosProvinciaAgregar(ref comando, prov);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spAgregarProvincia");
        }

        
        // AGREGAR ESTOS PROCEDIMIENTOS ALMACENADOS EN LA BD:
        /*
        CREATE PROCEDURE[dbo].[spEliminarProvincia]
        (
            @IDPROVINCIA INT
        ) AS
        DELETE Provincia WHERE Id_Provincia = @IDPROVINCIA
        RETURN
        */

        /*
        CREATE PROCEDURE[dbo].[spAgregarProvincia]
        (
        @IDPROVINCIA INT,
        @DESCRIPCIONPROV VARCHAR(50)
        ) AS
        INSERT INTO Provincia(Id_Provincia, DescripcionProvincia) VALUES(@IDPROVINCIA, @DESCRIPCIONPROV)
        RETURN   
        */
    }
}
