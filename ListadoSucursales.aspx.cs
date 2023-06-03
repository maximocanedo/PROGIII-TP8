using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico5 {
 
    public partial class ListadoSucursales : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void CargarDatos(bool seFiltra = false) {
            DataSet sucursales = seFiltra ?
            Sucursal.FiltrarSucursalesPorID(int.Parse(tbBuscarPorID.Text)) :
            Sucursal.ObtenerSucursales();
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
            CargarDatos(true);
        }

     
    }
}