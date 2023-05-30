<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="TrabajoPractico5.AgregarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <title>Material Design</title>
    <link href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" rel="stylesheet" />
    <script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <link href="./styles.css" rel="stylesheet" />
    <script src="./index.js"></script>
</head>
<body>
    <form id="form1" action="#" class="agregarSucursal" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br>
        <h1 class="mdc-typography--headline4">Agregar sucursal</h1>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="my-label-id1">Nombre de sucursal</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- TextBox @tbNombreSucursal -->
            <asp:TextBox ID="tbNombreSucursal" required minlength="1" CssClass="mdc-text-field__input" aria-labelledby="my-label-id1" runat="server" ValidationGroup="A"></asp:TextBox>
        </label>
        <div class="mdc-text-field-helper-line">
            <asp:RequiredFieldValidator ID="rfv1" CssClass="mdc-text-field-helper-text" aria-hidden="true" ControlToValidate="tbNombreSucursal" runat="server" ErrorMessage="" ValidationGroup="A" SetFocusOnError="True" Text="Tenés que ingresar un nombre."></asp:RequiredFieldValidator>
        </div>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="descripcion">Descripción</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- TextBox @tbDescripcion -->
            <asp:TextBox ID="tbDescripcion" required minlength="1" ValidationGroup="A" aria-labelledby="descripcion" CssClass="mdc-text-field__input" runat="server"></asp:TextBox>
       
        
        </label>
         <div class="mdc-text-field-helper-line">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" CssClass="mdc-text-field-helper-text" aria-hidden="true" ControlToValidate="tbDescripcion" runat="server" ErrorMessage="" ValidationGroup="A" SetFocusOnError="True" Text="Tenés que ingresar una descripción."></asp:RequiredFieldValidator>
        </div>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="my-label-id3">Provincia</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- DropDownList @ddlProvincias -->
            <asp:DropDownList ID="ddlProvincias" required ValidationGroup="A" CssClass="mdc-text-field__input" aria-labelledby="my-label-id3" runat="server">
              
            </asp:DropDownList>
            
        </label>
        <div class="mdc-text-field-helper-line">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" CssClass="mdc-text-field-helper-text" aria-hidden="true" ControlToValidate="ddlProvincias" runat="server" ErrorMessage="" ValidationGroup="A" SetFocusOnError="True" Text="Tenés que seleccionar una provincia." InitialValue="__NoProvinceSelected"></asp:RequiredFieldValidator>
        </div>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="direccion">Dirección</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- TextBox @tbDireccion -->
            <asp:TextBox ID="tbDireccion" required minlength="1" ValidationGroup="A" CssClass="mdc-text-field__input" aria-labelledby="direccion" runat="server"></asp:TextBox>
        </label>
        <div class="mdc-text-field-helper-line">
            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" CssClass="mdc-text-field-helper-text" aria-hidden="true" ControlToValidate="tbDireccion" runat="server" ErrorMessage="" ValidationGroup="A" SetFocusOnError="True" Text="Tenés que ingresar una dirección."></asp:RequiredFieldValidator>
        </div>
        <br />
        <asp:LinkButton ID="btnAceptar"  ValidationGroup="A" CssClass="mdc-button mdc-button--raised" runat="server" Text="Aceptar" OnClick="btnAceptar_Click" UseSubmitBehavior="False" />

        <aside class="mdc-snackbar">
            <div class="mdc-snackbar__surface" role="status" aria-relevant="additions">
                <div class="mdc-snackbar__label" aria-atomic="false"></div>
            </div>
        </aside>
    </form>
</body>
</html>
