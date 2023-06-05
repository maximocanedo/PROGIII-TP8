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
    public class DaoSucursal
    {
        AccesoDatos ad = new AccesoDatos();

        public Sucursal getSucursal(Sucursal suc)
        {
            DataTable tabla = ad.ObtenerTabla("Sucursal", "SELECT * FROM Sucursal WHERE Id_Sucursal = " + suc.getID());
            suc.setID(Convert.ToInt32(tabla.Rows[0][0].ToString()));
            suc.setNombre(tabla.Rows[0][1].ToString());
            suc.setDescripcion(tabla.Rows[0][2].ToString());
            suc.setProvincia(Convert.ToInt32(tabla.Rows[0][3].ToString()));
            suc.setDireccion(tabla.Rows[0][4].ToString());
            return suc;
        }

        public Boolean existeSucursal(Sucursal suc)
        {
            String consulta = "SELECT * FROM Sucursal WHERE Id_Sucursal = " + suc.getID();
            return ad.existe(consulta);
        }

        public DataTable getTablaSucursales()
        {
            DataTable tabla = ad.ObtenerTabla("Sucursal", "SELECT * FROM Sucursal");
            return tabla;
        } 

        private void ArmarParametrosSucursalEliminar(ref SqlCommand Comando, Sucursal suc)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDSUCURSAL", SqlDbType.Int);
            SqlParametros.Value = suc.getID();
        }

        public int eliminarSucursal(Sucursal suc)
        {
            SqlCommand comando = new SqlCommand();
            ArmarParametrosSucursalEliminar(ref comando, suc);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spEliminarSucursal");
        }

        private void ArmarParametrosSucursalAgregar(ref SqlCommand Comando, Sucursal suc)
        {
            SqlParameter SqlParametros = new SqlParameter();
            SqlParametros = Comando.Parameters.Add("@IDSUCURSAL", SqlDbType.Int);
            SqlParametros.Value = suc.getID();
            SqlParametros = Comando.Parameters.Add("@NOMBRESUC", SqlDbType.VarChar);
            SqlParametros.Value = suc.getNombre();
            SqlParametros = Comando.Parameters.Add("@DESCRIPCIONSUC", SqlDbType.VarChar);
            SqlParametros.Value = suc.getDescripcion();
            SqlParametros = Comando.Parameters.Add("@PROVINCIASUC", SqlDbType.Int);
            SqlParametros.Value = suc.getProvincia();
            SqlParametros = Comando.Parameters.Add("@DIRECCIONSUC", SqlDbType.VarChar);
            SqlParametros.Value = suc.getDireccion();
        }

        public int agregarSucursal(Sucursal suc)
        {
            suc.setID(ad.ObtenerMaximo("SELECT MAX(Id_Sucursal) FROM Sucursal") + 1);
            SqlCommand comando = new SqlCommand();
            ArmarParametrosSucursalAgregar(ref comando, suc);
            return ad.EjecutarProcedimientoAlmacenado(comando, "spAgregarSucursal");
        }

        // AGREGAR ESTOS PROCEDIMIENTOS ALMACENADOS EN LA BD:
        /*
        CREATE PROCEDURE[dbo].[spEliminarSucursal]
        (
            @IDSUCURSAL INT
        ) AS
        DELETE Sucursal WHERE Id_Sucursal = @IDSUCURSAL
        RETURN
        */

        /*
        CREATE PROCEDURE[dbo].[spAgregarSucursal]
        (
        @IDSUCURSAL INT,
        @NOMBRESUC VARCHAR(100),
        @DESCRIPCIONSUC VARCHAR(100),
        @PROVINCIASUC INT,
        @DIRECCIONSUC VARCHAR(100)
        ) AS
        INSERT INTO Sucursal(Id_Sucursal, NombreSucursal, DescripcionSucursal, Id_ProvinciaSucursal, DireccionSucursal) VALUES(@IDSUCURSAL, @NOMBRESUC, @DESCRIPCIONSUC, @PROVINCIASUC, @DIRECCIONSUC)
        RETURN
        */
    }
}
