﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursales.aspx.cs" Inherits="TrabajoPractico5.ListadoSucursales" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
    <head runat="server">
    <!-- Título y descripción -->
    <title>Listar Sucursales · T.P. N.º 8</title>
    <meta name="description" content="
        Página 'Listar Sucursales' del Trabajo Práctico N.º 8 para la materia Programación III. 
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
    <form id="form1" class="agregarSucursal" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <br/>
        <h1 class="mdc-typography--headline4">Todas las sucursales</h1>
        <div class="flex-horizontal">
            <label class="mdc-text-field mdc-text-field--outlined">
                <span class="mdc-notched-outline">
                  <span class="mdc-notched-outline__leading"></span>
                  <span class="mdc-notched-outline__notch">
                    <span class="mdc-floating-label" id="my-label-id1">Buscar por ID</span>
                  </span>
                  <span class="mdc-notched-outline__trailing"></span>
                </span>
                <asp:TextBox ID="tbBuscarPorID" CssClass="mdc-text-field__input" aria-labelledby="my-label-id1" runat="server"></asp:TextBox>
              </label>
            <asp:LinkButton ID="btnBuscar" CssClass="mdc-button mdc-button--raised" runat="server" Text="Buscar" OnClick="FiltraSucursales" />
        </div>
        <br />
        <asp:GridView ID="gvSucursales" CssClass="mdc-typography--body2" runat="server"></asp:GridView>

        <aside class="mdc-snackbar">
            <div class="mdc-snackbar__surface" role="status" aria-relevant="additions">
              <div class="mdc-snackbar__label" aria-atomic="false">
                Mensaje
              </div>
            </div>
          </aside>
    </form>
</body>
</html>
