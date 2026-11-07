<%@ Page Title="Registro de Productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebExamenFinalDG.Default" %>
<asp:Content ID="cntInicioDG" ContentPlaceHolderID="cphContenidoDG" runat="server">
    <h2 class="mb-4">Vista Previa: Pantalla de Registro de Productos</h2>

    <asp:Panel ID="pnlMensajeDG" runat="server" Visible="false" role="alert">
        <asp:Label ID="lblMensajeDG" runat="server" />
    </asp:Panel>

    <div class="row g-4">
        <div class="col-lg-5">
            <div class="card tarjeta-dg">
                <div class="card-body">
                    <h5 class="card-title">&#128230; Nuevo Producto</h5>
                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtCodigoDG" Text="Código de Producto:" />
                        <asp:TextBox ID="txtCodigoDG" runat="server" CssClass="form-control" MaxLength="20" placeholder="PRD-001" />
                        <asp:RequiredFieldValidator ID="rfvCodigoDG" runat="server" ControlToValidate="txtCodigoDG" ErrorMessage="El código es obligatorio." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                        <asp:RegularExpressionValidator ID="revCodigoDG" runat="server" ControlToValidate="txtCodigoDG" ValidationExpression="^[A-Za-z0-9\-]{1,20}$" ErrorMessage="Use solo letras, números y guiones (ej. PRD-001)." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                    </div>
                    <div class="mb-3">
                        <asp:Label runat="server" AssociatedControlID="txtNombreDG" Text="Nombre del Producto:" />
                        <asp:TextBox ID="txtNombreDG" runat="server" CssClass="form-control" MaxLength="100" placeholder="Laptop Educativa" />
                        <asp:RequiredFieldValidator ID="rfvNombreDG" runat="server" ControlToValidate="txtNombreDG" ErrorMessage="El nombre es obligatorio." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                    </div>
                    <div class="row">
                        <div class="col-6 mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtPrecioDG" Text="Precio ($):" />
                            <asp:TextBox ID="txtPrecioDG" runat="server" CssClass="form-control" placeholder="450.00" />
                            <asp:RequiredFieldValidator ID="rfvPrecioDG" runat="server" ControlToValidate="txtPrecioDG" ErrorMessage="El precio es obligatorio." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                            <asp:RegularExpressionValidator ID="revPrecioDG" runat="server" ControlToValidate="txtPrecioDG" ValidationExpression="^\d{1,8}(\.\d{1,2})?$" ErrorMessage="Número con máximo 2 decimales." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                        </div>
                        <div class="col-6 mb-3">
                            <asp:Label runat="server" AssociatedControlID="txtStockDG" Text="Stock:" />
                            <asp:TextBox ID="txtStockDG" runat="server" CssClass="form-control" placeholder="25" />
                            <asp:RequiredFieldValidator ID="rfvStockDG" runat="server" ControlToValidate="txtStockDG" ErrorMessage="El stock es obligatorio." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                            <asp:RangeValidator ID="rvStockDG" runat="server" ControlToValidate="txtStockDG" Type="Integer" MinimumValue="0" MaximumValue="1000000" ErrorMessage="Entero entre 0 y 1,000,000." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                        </div>
                    </div>
                    <asp:Button ID="btnGuardarDG" runat="server" Text="Guardar Producto" CssClass="btn btn-dark w-100" ValidationGroup="vgProductoDG" OnClick="btnGuardarDG_Click" />
                </div>
            </div>
        </div>

        <div class="col-lg-7">
            <div class="card tarjeta-dg">
                <div class="card-body">
                    <h5 class="card-title text-dark">&#9638; Inventario Actual</h5>
                    <asp:GridView ID="gvInventarioDG" runat="server" AutoGenerateColumns="false" DataKeyNames="IdProductoDG"
                        CssClass="table table-hover tabla-dg mb-0" GridLines="None" ShowHeaderWhenEmpty="true"
                        EmptyDataText="No hay productos registrados." OnRowCommand="gvInventarioDG_RowCommand">
                        <Columns>
                            <asp:BoundField DataField="CodigoDG" HeaderText="Código" />
                            <asp:BoundField DataField="NombreDG" HeaderText="Nombre" />
                            <asp:BoundField DataField="PrecioDG" HeaderText="Precio" DataFormatString="${0:#,##0.00}" HtmlEncode="true" />
                            <asp:BoundField DataField="StockDG" HeaderText="Stock" />
                            <asp:TemplateField HeaderText="Acciones">
                                <ItemTemplate>
                                    <asp:Button ID="btnEliminarDG" runat="server" Text="Eliminar" CssClass="btn btn-danger btn-sm"
                                        CommandName="EliminarDG" CommandArgument='<%# Eval("IdProductoDG") %>' CausesValidation="false"
                                        OnClientClick="return confirm('¿Seguro que desea eliminar este producto?');" />
                                </ItemTemplate>
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
