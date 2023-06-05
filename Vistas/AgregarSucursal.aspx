<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AgregarSucursal.aspx.cs" Inherits="Vistas.AgregarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 80px;
        }
        .auto-style2 {
            width: 100%;
        }
        .auto-style9 {
            width: 227px;
            height: 35px;
        }
        .auto-style11 {
            width: 248px;
            height: 35px;
        }
        .auto-style10 {
            width: 1778px;
            height: 35px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="auto-style1">
            <asp:HyperLink ID="hlAgregarSucursal" runat="server" NavigateUrl="AgregarSucursal.aspx">Agregar Sucursal</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlListadoSucursales" runat="server" NavigateUrl="ListadoSucursales.aspx">Listado de Sucursales</asp:HyperLink>
            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
            <asp:HyperLink ID="hlEliminarSucursal" runat="server" NavigateUrl="EliminarSucursal.aspx">Eliminar Sucursal</asp:HyperLink>
        </div>
        <br />
        <asp:Label ID="lblGrupoNº5" runat="server" Font-Bold="True" Font-Size="X-Large" Text="GRUPO Nº 5"></asp:Label>
        <br />
        <br />
        <asp:Label ID="lblAgregarSucursal" runat="server" Font-Bold="True" Font-Size="Large" Text="Agregar Sucursal"></asp:Label>
        <br />
        <br />
        <table class="auto-style2">
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblNombreSucursal" runat="server" Text="Nombre sucursal:"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtNombreSucursal" runat="server"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="rfvNombreSucursal" runat="server" ControlToValidate="txtNombreSucursal" ErrorMessage="*Debe ingresar un nombre de sucursal." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblDescripción" runat="server" Text="Descripción:"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtDescripción" runat="server" Font-Overline="True"></asp:TextBox>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="rfvDescripción" runat="server" ControlToValidate="txtDescripción" ErrorMessage="*Debe ingresar una descripción." ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblProvincia" runat="server" Text="Provincia:"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:DropDownList ID="ddlProvincias" runat="server">
                    </asp:DropDownList>
                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; </td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="rfvProvincias" runat="server" ControlToValidate="ddlProvincias" ErrorMessage="*Debe seleccionar una provincia." ForeColor="Red" InitialValue="--Seleccione una provincia.--"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="auto-style9">
                    <asp:Label ID="lblDirección" runat="server" Text="Dirección:"></asp:Label>
                </td>
                <td class="auto-style11">
                    <asp:TextBox ID="txtDirección" runat="server"></asp:TextBox>
                </td>
                <td class="auto-style10">
                    <asp:RequiredFieldValidator ID="rfvDirección" runat="server" ControlToValidate="txtDirección" ErrorMessage="*Debe ingresar una dirección" ForeColor="Red"></asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
        <br />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnAceptar" runat="server" OnClick="btnAceptar_Click" Text="Aceptar" />
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
