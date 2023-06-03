﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TrabajoPractico5 {
    
    public partial class EliminarSucursal : System.Web.UI.Page {
        private void MostrarMensaje(string mensaje) {
            string script = "MostrarMensaje('" + mensaje + "');";
            ScriptManager.RegisterStartupScript(this, GetType(), "MostrarMensaje", script, true);
        }
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnEliminar_Click(object sender, EventArgs e) {
            var miSucursal = new Sucursal() { id = int.Parse(tbIDSucursal.Text) };
            var response = miSucursal.Eliminar();
            tbIDSucursal.Text = "";
            MostrarMensaje(
                response.FilasAfectadas == 1 
                ? "El registro #" + miSucursal.id + " fue eliminado exitósamente de la base de datos. "
                : "Hubo un problema al intentar eliminar el registro especificado. "
                );
            
        }
    }
}