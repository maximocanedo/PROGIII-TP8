using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Entidades;
using Negocio;

namespace TrabajoPractico5 {
    public partial class AgregarSucursal : System.Web.UI.Page {
        public void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {
            /* Controles de esta página:
             * tbNombreSucursal (TextBox)
             * tbDescripcion (TextBox)
             * ddlProvincias (DropDownList)
             * tbDireccion (TextBox)
             * btnAceptar (Button)
             */
            if(!IsPostBack) {
                DataSet provincias = ProvinciaNegocio.ObtenerProvincias();
                ddlProvincias.DataSource = provincias.Tables[0];
                ddlProvincias.DataValueField = "Id_Provincia";
                ddlProvincias.DataTextField = "DescripcionProvincia";
                ddlProvincias.DataBind();
                ddlProvincias.Items.Insert(0, new ListItem("Seleccioná una provincia", "__NoProvinceSelected"));
            }
            
        }
        protected void LimpiarCampos() {
            tbNombreSucursal.Text = "";
            tbDescripcion.Text = "";
            ddlProvincias.SelectedIndex = 0;
            tbDireccion.Text = "";

        }
        protected void btnAceptar_Click(object sender, EventArgs e) {
            var miSucursal = new Sucursal() {
                Nombre1 = tbNombreSucursal.Text,
                Descripcion1 = tbDescripcion.Text,
                IDProvincia1 = int.Parse(ddlProvincias.SelectedValue),
                Direccion1 = tbDireccion.Text
            };
            var response = SucursalNegocio.Escribir(miSucursal);
            if (response.FilasAfectadas == 1) {
                LimpiarCampos();
                MostrarMensaje("El registro se ha agregado con éxito. ");
            }
            
        }
    }
}