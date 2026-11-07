<%@ Page Title="Acerca de esta aplicación" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="WebExamenFinalDG.About" %>
<asp:Content ID="cntAcercaDG" ContentPlaceHolderID="cphContenidoDG" runat="server">
    <div class="titulo-pagina-dg">
        <h1>Acerca de esta aplicación</h1>
        <p>Sistema web para el control de productos.</p>
    </div>
    <div class="row g-4">
        <div class="col-lg-7">
            <div class="ficha-dg">
                <h2>¿Qué es?</h2>
                <p>Esta página fue realizada en Visual Studio con C# y se considera una página para el control de productos de la Universidad Mariano Gálvez de Guatemala.</p>
                <p class="mb-0">Permite registrar productos con su código, nombre, precio y existencias, consultarlos en el inventario y eliminarlos con confirmación. Toda la información se guarda en SQL Server.</p>
            </div>
        </div>
        <div class="col-lg-5">
            <div class="ficha-dg">
                <h2>Tecnologías</h2>
                <span class="etiqueta-tec-dg">C#</span>
                <span class="etiqueta-tec-dg">ASP.NET Web Forms</span>
                <span class="etiqueta-tec-dg">.NET Framework 4.8</span>
                <span class="etiqueta-tec-dg">Bootstrap</span>
                <span class="etiqueta-tec-dg">SQL Server</span>
                <p class="mt-3 mb-0">Arquitectura en capas: CapaEntidadesDG, CapaDatosDG, CapaNegocioDG y la capa de presentación WebExamenFinalDG.</p>
            </div>
        </div>
    </div>
</asp:Content>
