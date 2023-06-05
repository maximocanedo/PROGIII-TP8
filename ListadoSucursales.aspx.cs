using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Negocio;
using Entidades;
namespace TrabajoPractico5 {
 
    public partial class ListadoSucursales : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
       
        protected void CargarDatos() {
            DataSet sucursales =SucursalNegocio.ObtenerSucursales();
            gvSucursales.DataSource = sucursales.Tables["root"];
            gvSucursales.DataBind();
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CargarDatos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e) {
            MostrarMensaje("¡Evento click del @btnBuscar activado!");
        }

        protected void FiltraSucursales(object sender, EventArgs e)
        {
            string texto = tbBuscarPorID.Text;
            int valor;
            if (!string.IsNullOrEmpty(texto) && int.TryParse(texto, out valor))
            {
                Sucursal sucursal = new Sucursal();
                sucursal.Id1 = int.Parse(tbBuscarPorID.Text);
                DataSet sucursales = SucursalNegocio.FiltrarSucursalesPorID(sucursal);
                gvSucursales.DataSource = sucursales.Tables["root"];
                gvSucursales.DataBind();
            }
            else
            {
                CargarDatos();
            }
        }
    }
}