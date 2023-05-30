using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entity;
using BusinessLogic;

namespace TrabajoPractico5 {
 
    public partial class ListadoSucursales : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void CargarDatos(bool seFiltra = false) {
            Response operacion = seFiltra
                ? SucursalLogic.FiltrarSucursalesPorID(int.Parse(tbBuscarPorID.Text))
                : SucursalLogic.ObtenerSucursales();
            if(!operacion.ErrorFound && operacion.ObjectReturned != null) {
                DataSet sucursales = (DataSet)operacion.ObjectReturned;
                gvSucursales.DataSource = sucursales.Tables["root"];
                gvSucursales.DataBind();
            } else {
                MostrarMensaje("Hubo un error al intentar obtener los datos. Detalles: " + operacion.Details);
            }
        }
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                CargarDatos();
            }
        }

        protected void btnBuscar_Click(object sender, EventArgs e) {
            //MostrarMensaje("¡Evento click del @btnBuscar activado!");
            CargarDatos(true);
        }
    }
}