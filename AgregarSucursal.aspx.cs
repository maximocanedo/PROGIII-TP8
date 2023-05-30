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
                Response operacion = ProvinciaLogic.ObtenerProvincias();
                if(!operacion.ErrorFound && operacion.ObjectReturned != null) {
                    DataSet provincias = (DataSet)operacion.ObjectReturned;
                    ddlProvincias.DataSource = provincias.Tables[0];
                    ddlProvincias.DataValueField = "Id_Provincia";
                    ddlProvincias.DataTextField = "DescripcionProvincia";
                    ddlProvincias.DataBind();
                    ddlProvincias.Items.Insert(0, new ListItem("Seleccioná una provincia", "__NoProvinceSelected"));
                } else {
                    MostrarMensaje("Hubo un error al intentar cargar las provincias. " + operacion.Details);
                }
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
                Nombre = tbNombreSucursal.Text,
                Descripcion = tbDescripcion.Text,
                Provincia = int.Parse(ddlProvincias.SelectedValue),
                Direccion = tbDireccion.Text
            };
            var response = SucursalLogic.Escribir(miSucursal);
            if (response.AffectedRows == 1) {
                LimpiarCampos();
                MostrarMensaje("El registro se ha agregado con éxito. ");
            }
            
        }
    }
}