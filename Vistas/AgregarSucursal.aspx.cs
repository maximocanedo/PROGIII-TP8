using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Entidades;
using Negocio;

namespace Vistas
{
    public partial class AgregarSucursal : System.Web.UI.Page
    {
        NegocioSucursal suc = new NegocioSucursal();
        NegocioProvincia prov = new NegocioProvincia();
        public void limpiarCampos()
        {
            txtNombreSucursal.Text = "";
            txtDescripción.Text = "";
            ddlProvincias.SelectedIndex = 0;
            txtDirección.Text = "";
        }

        // Cargo las provincias de la BDSucursales en el DropDownList.
        public void mostrarProvinciasEnDDL(DropDownList provincias, string consulta)
        {
            provincias.DataSource = prov.getTabla(); // vuelco el DataTable en el DropDownList.
            provincias.DataTextField = "DescripcionProvincia"; // seteo qué columna de la base de datos quiero que se muestre.
            provincias.DataValueField = "Id_Provincia"; // seteo qué columna de la base de datos quiero que valga internamente.
            provincias.DataBind(); // realizo la vinculación para que se pueda visualizar el contenido.
            provincias.Items.Insert(0, new ListItem("--Seleccione una provincia.--", "--Seleccione una provincia.--")); // se inserta el item en el índice 0.
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            ValidationSettings.UnobtrusiveValidationMode = UnobtrusiveValidationMode.None;
            if (!IsPostBack)
            {
                // Se muestran (en el DropDownList de las provincias) todas las provincias disponibles de la base de datos.
                string consultaSQL = "SELECT * FROM Provincia";
                mostrarProvinciasEnDDL(ddlProvincias, consultaSQL);
            }
        }

        protected void btnAceptar_Click(object sender, EventArgs e)
        {
            if(suc.agregarSucursal(txtNombreSucursal.Text, txtDescripción.Text, Convert.ToInt32(ddlProvincias.SelectedValue), txtDirección.Text))
            {
                lblMensaje.ForeColor = System.Drawing.Color.Green;
                lblMensaje.Text = "La sucursal se ha agregado con éxito.";
            }
            else
            {
                lblMensaje.ForeColor = System.Drawing.Color.Red;
                lblMensaje.Text = "No es posible agregar la sucursal. Ya existe dicha sucursal en la Base de Datos.";
            }

            // Limpio los TextBox y le cambio al DDL la opción a la por defecto.
            limpiarCampos();
        }
    }
}