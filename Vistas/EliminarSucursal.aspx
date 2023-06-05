<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EliminarSucursal.aspx.cs" Inherits="Vistas.EliminarSucursal" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    <style type="text/css">
        .auto-style1 {
            margin-left: 80px;
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
        <p>
            <asp:Label ID="lblEliminarSucursal" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Eliminar Sucursal"></asp:Label>
        </p>
        <asp:Label ID="lblIngresarID" runat="server" Text="Ingresar ID de sucursal:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtIngresarID" runat="server" TextMode="Number"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnEliminar" runat="server" OnClick="btnEliminar_Click" Text="Eliminar" />
        <br />
        <br />
        <asp:Label ID="lblMensaje" runat="server"></asp:Label>
    </form>
</body>
</html>
