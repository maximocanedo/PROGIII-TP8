﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarSucursal.aspx.cs" Inherits="TrabajoPractico5.EliminarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <!-- Título y descripción -->
    <title>Eliminar Sucursal · T.P. N.º 8</title>
    <meta name="description" content="
        Página 'Eliminar Sucursal' del Trabajo Práctico N.º 8 para la materia Programación III. 
        Universidad Tecnológica Nacional, Facultad Regional General Pacheco. 
        Repositorio disponible aquí:  https://github.com/maximocanedo/PROGIII-TP8" />
    <!-- Integrantes -->
    <meta name="author" content="Ezequiel Martínez" />
    <meta name="author" content="Javier Torales" />
    <meta name="author" content="Jean Pierre Esquén" />
    <meta name="author" content="María Olivia Hanczyc" />
    <meta name="author" content="Máximo Canedo" />
    <!-- Otras metaetiquetas útiles -->
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <!-- Librerías utilizadas -->
    <link href="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.css" rel="stylesheet" />
    <script src="https://unpkg.com/material-components-web@latest/dist/material-components-web.min.js"></script>
    <link rel="stylesheet" href="https://fonts.googleapis.com/icon?family=Material+Icons" />
    <!-- Archivos usados -->
    <link rel="icon" href="utn.ico" type="image/x-icon" />
    <link href="./styles.css" rel="stylesheet" />
    <script src="./index.js"></script>
</head>
<body>
    <form id="form1" action="#" class="agregarSucursal" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br>
        <h1 class="mdc-typography--headline4">Eliminar una sucursal</h1>
        <br />
        <label class="mdc-text-field mdc-text-field--outlined">
            <span class="mdc-notched-outline">
                <span class="mdc-notched-outline__leading"></span>
                <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="my-label-id1">ID de sucursal</span>
                </span>
                <span class="mdc-notched-outline__trailing"></span>
            </span>
            <!-- TextBox @tbNombreSucursal -->
            <asp:TextBox ID="tbIDSucursal" required minlength="1" type="number" ValidationGroup="A" CssClass="mdc-text-field__input" aria-labelledby="my-label-id1" runat="server"></asp:TextBox>
        </label>
        <div class="mdc-text-field-helper-line">
            <asp:RequiredFieldValidator ID="rfv1" CssClass="mdc-text-field-helper-text" aria-hidden="true" ControlToValidate="tbIDSucursal" runat="server" ErrorMessage="" ValidationGroup="A" SetFocusOnError="True" Text="Ingresá un ID válido"></asp:RequiredFieldValidator>
        </div>
        <br />
        <asp:LinkButton ID="btnEliminar" ValidationGroup="A" CssClass="mdc-button mdc-button--raised mdc-delete" runat="server" Text="Eliminar permanentemente" UseSubmitBehavior="False" OnClick="btnEliminar_Click" />

        <aside class="mdc-snackbar">
            <div class="mdc-snackbar__surface" role="status" aria-relevant="additions">
                <div class="mdc-snackbar__label" aria-atomic="false"></div>
            </div>
        </aside>
    </form>
</body>
</html>
