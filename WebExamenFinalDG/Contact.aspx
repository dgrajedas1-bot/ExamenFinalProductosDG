<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebExamenFinalDG.Contact" %>
<asp:Content ID="cntContactoDG" ContentPlaceHolderID="cphContenidoDG" runat="server">
    <h1 class="display-6">INFORMACION DEL ALUMNO.</h1>
    <h3>DETALLES</h3>
    <address>
        <asp:Label ID="lblNombreDG" runat="server" /><br />
        CARNE: <asp:Label ID="lblCarneDG" runat="server" /><br />
        <abbr title="Sección">Seccion:</abbr> <asp:Label ID="lblSeccionDG" runat="server" />
    </address>
    <address>
        <asp:PlaceHolder ID="phCorreoDG" runat="server" Visible="false">
            <strong>Soporte:</strong> <asp:HyperLink ID="hlCorreoDG" runat="server" /><br />
        </asp:PlaceHolder>
        <strong>Curso:</strong> <asp:Label ID="lblCursoDG" runat="server" CssClass="text-primary" />
    </address>
</asp:Content>
