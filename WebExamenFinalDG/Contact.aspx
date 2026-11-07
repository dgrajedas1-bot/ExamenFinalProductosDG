<%@ Page Title="Contacto" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="WebExamenFinalDG.Contact" %>
<asp:Content ID="cntContactoDG" ContentPlaceHolderID="cphContenidoDG" runat="server">
    <div class="titulo-pagina-dg">
        <h1>Información del alumno</h1>
        <p>Datos de la estudiante que desarrolló esta aplicación.</p>
    </div>
    <div class="row">
        <div class="col-md-8 col-lg-6">
            <div class="ficha-dg">
                <h2>Detalles</h2>
                <dl class="mb-0">
                    <dt>Nombre</dt>
                    <dd><asp:Label ID="lblNombreDG" runat="server" /></dd>
                    <dt>Carné</dt>
                    <dd><asp:Label ID="lblCarneDG" runat="server" /></dd>
                    <dt>Sección</dt>
                    <dd><asp:Label ID="lblSeccionDG" runat="server" /></dd>
                    <dt>Curso</dt>
                    <dd><asp:Label ID="lblCursoDG" runat="server" /></dd>
                    <asp:PlaceHolder ID="phCorreoDG" runat="server" Visible="false">
                        <dt>Soporte</dt>
                        <dd><asp:HyperLink ID="hlCorreoDG" runat="server" /></dd>
                    </asp:PlaceHolder>
                </dl>
            </div>
        </div>
    </div>
</asp:Content>
