using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entidades;
using DAO;
using System.Data;

namespace Negocio
{
    public class NegocioSucursal
    {
        public DataTable getTabla()
        {
            DaoSucursal dao = new DaoSucursal();
            return dao.getTablaSucursales();
        }

        public Sucursal get(int id)
        {
            DaoSucursal dao = new DaoSucursal();
            Sucursal suc = new Sucursal();
            suc.setID(id);
            return dao.getSucursal(suc);
        }

        public bool eliminarSucursal(int id)
        {
            DaoSucursal dao = new DaoSucursal();
            Sucursal suc = new Sucursal();
            suc.setID(id);
            // Verifico si el ID existe en la Base de Datos:
            if (!dao.existeSucursal(suc))
            {
                int filasAfectadas = dao.eliminarSucursal(suc);
                if (filasAfectadas == 1) { return true; }
                else { return false; }
            }
            else { return false; }
        }

        public bool agregarSucursal(String nombre, String descripcion, int provincia, String direccion)
        {
            DaoSucursal dao = new DaoSucursal();
            Sucursal suc = new Sucursal();
            suc.setNombre(nombre);
            suc.setDireccion(descripcion);
            suc.setProvincia(provincia);
            suc.setDireccion(direccion);
            // Verifico si el ID existe en la Base de Datos:
            if (dao.agregarSucursal(suc) == 1) { return true; }
            else { return false; }
        }
    }
}
