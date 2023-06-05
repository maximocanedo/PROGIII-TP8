<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ListadoSucursales.aspx.cs" Inherits="Vistas.ListadoSucursales" %>

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
            <asp:Label ID="lblListadoSucursales" runat="server" Font-Bold="True" Font-Size="X-Large" Text="Listado de sucursales"></asp:Label>
        </p>
        <asp:Label ID="lblBusqueda" runat="server" Text="Búsqueda - Ingrese ID de la sucursal:"></asp:Label>
        &nbsp;&nbsp;&nbsp;
        <asp:TextBox ID="txtIngresarID" runat="server"></asp:TextBox>
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnFiltrar" runat="server" OnClick="btnFiltrar_Click" Text="Filtrar" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
        <asp:Button ID="btnMostrarTodas" runat="server" OnClick="btnMostrarTodas_Click" Text="Mostrar todas las sucursales" />
        <br />
        <br />
        <asp:GridView ID="gvSucursales" runat="server">
        </asp:GridView>
    </form>
</body>
</html>
