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
    public class NegocioProvincia
    {
        public DataTable getTabla()
        {
            DaoProvincia dao = new DaoProvincia();
            return dao.getTablaProvincias();
        }

        public Provincia get(int id)
        {
            DaoProvincia dao = new DaoProvincia();
            Provincia prov = new Provincia();
            prov.setID(id);
            return dao.getProvincia(prov);
        }

        public bool eliminarProvincia(int id)
        {
            DaoProvincia dao = new DaoProvincia();
            Provincia prov = new Provincia();
            prov.setID(id);
            // Verifico si el ID existe en la Base de Datos:
            if (!dao.existeProvincia(prov))
            {
                int filasAfectadas = dao.eliminarProvincia(prov);
                if (filasAfectadas == 1) { return true; }
                else { return false; }
            }
            else { return false; }
        }

        public bool agregarProvincia(int id)
        {
            DaoProvincia dao = new DaoProvincia();
            Provincia prov = new Provincia();
            prov.setID(id);
            // Verifico si el ID existe en la Base de Datos:
            if (!dao.existeProvincia(prov))
            {
                int filasAfectadas = dao.agregarProvincia(prov);
                if (filasAfectadas == 1) { return true; }
                else { return false; }
            }
            else { return false; }
        }
    }
}
