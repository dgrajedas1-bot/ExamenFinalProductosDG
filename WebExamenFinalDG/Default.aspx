<%@ Page Title="Inventario de productos" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebExamenFinalDG.Default" %>
<asp:Content ID="cntInicioDG" ContentPlaceHolderID="cphContenidoDG" runat="server">
    <div class="titulo-pagina-dg">
        <h1>Inventario de productos</h1>
        <p>Registre productos nuevos y administre las existencias guardadas en la base de datos.</p>
    </div>

    <asp:Panel ID="pnlMensajeDG" runat="server" Visible="false" role="alert">
        <asp:Label ID="lblMensajeDG" runat="server" />
    </asp:Panel>

    <section class="registro-dg mb-4" aria-labelledby="ttlRegistroDG">
        <h2 id="ttlRegistroDG">Registrar producto <small>· todos los campos son obligatorios</small></h2>
        <div class="row g-3 align-items-start">
            <div class="col-sm-6 col-lg-2">
                <asp:Label runat="server" AssociatedControlID="txtCodigoDG" Text="Código" />
                <asp:TextBox ID="txtCodigoDG" runat="server" CssClass="form-control" MaxLength="20" placeholder="PRD-004" />
                <asp:RequiredFieldValidator ID="rfvCodigoDG" runat="server" ControlToValidate="txtCodigoDG" ErrorMessage="Ingrese el código." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                <asp:RegularExpressionValidator ID="revCodigoDG" runat="server" ControlToValidate="txtCodigoDG" ValidationExpression="^[A-Za-z0-9\-]{1,20}$" ErrorMessage="Solo letras, números y guiones." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
            </div>
            <div class="col-sm-6 col-lg-4">
                <asp:Label runat="server" AssociatedControlID="txtNombreDG" Text="Nombre del producto" />
                <asp:TextBox ID="txtNombreDG" runat="server" CssClass="form-control" MaxLength="100" placeholder="Ej. Calculadora científica" />
                <asp:RequiredFieldValidator ID="rfvNombreDG" runat="server" ControlToValidate="txtNombreDG" ErrorMessage="Ingrese el nombre." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
            </div>
            <div class="col-6 col-lg-2">
                <asp:Label runat="server" AssociatedControlID="txtPrecioDG" Text="Precio ($)" />
                <asp:TextBox ID="txtPrecioDG" runat="server" CssClass="form-control" placeholder="0.00" />
                <asp:RequiredFieldValidator ID="rfvPrecioDG" runat="server" ControlToValidate="txtPrecioDG" ErrorMessage="Ingrese el precio." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                <asp:RegularExpressionValidator ID="revPrecioDG" runat="server" ControlToValidate="txtPrecioDG" ValidationExpression="^\d{1,8}(\.\d{1,2})?$" ErrorMessage="Número con máximo 2 decimales." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
            </div>
            <div class="col-6 col-lg-2">
                <asp:Label runat="server" AssociatedControlID="txtStockDG" Text="Existencias" />
                <asp:TextBox ID="txtStockDG" runat="server" CssClass="form-control" placeholder="0" />
                <asp:RequiredFieldValidator ID="rfvStockDG" runat="server" ControlToValidate="txtStockDG" ErrorMessage="Ingrese el stock." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
                <asp:RangeValidator ID="rvStockDG" runat="server" ControlToValidate="txtStockDG" Type="Integer" MinimumValue="0" MaximumValue="1000000" ErrorMessage="Entero de 0 a 1,000,000." CssClass="validador-dg" Display="Dynamic" ValidationGroup="vgProductoDG" />
            </div>
            <div class="col-lg-2 d-grid">
                <span class="d-none d-lg-block" style="height:1.45rem"></span>
                <asp:Button ID="btnGuardarDG" runat="server" Text="Guardar" CssClass="btn btn-coral-dg py-2" ValidationGroup="vgProductoDG" OnClick="btnGuardarDG_Click" />
            </div>
        </div>
    </section>

    <section class="inventario-dg" aria-labelledby="ttlInventarioDG">
        <div class="inventario-cabecera-dg">
            <h2 id="ttlInventarioDG">Productos en inventario</h2>
            <asp:Label ID="lblContadorDG" runat="server" CssClass="contador-dg" />
        </div>
        <div class="table-responsive">
            <asp:GridView ID="gvInventarioDG" runat="server" AutoGenerateColumns="false" DataKeyNames="IdProductoDG"
                CssClass="table tabla-dg" GridLines="None" ShowHeaderWhenEmpty="true"
                OnRowCommand="gvInventarioDG_RowCommand">
                <EmptyDataTemplate>
                    <div class="vacio-dg">Aún no hay productos registrados. Use el formulario de arriba para agregar el primero.</div>
                </EmptyDataTemplate>
                <Columns>
                    <asp:TemplateField HeaderText="Código">
                        <ItemTemplate><span class="codigo-dg"><%#: Eval("CodigoDG") %></span></ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField DataField="NombreDG" HeaderText="Producto" />
                    <asp:BoundField DataField="PrecioDG" HeaderText="Precio" DataFormatString="${0:#,##0.00}" ItemStyle-CssClass="text-end" HeaderStyle-CssClass="text-end" />
                    <asp:BoundField DataField="StockDG" HeaderText="Existencias" ItemStyle-CssClass="text-end" HeaderStyle-CssClass="text-end" />
                    <asp:TemplateField HeaderText="Acción" ItemStyle-CssClass="text-end" HeaderStyle-CssClass="text-end">
                        <ItemTemplate>
                            <asp:Button ID="btnEliminarDG" runat="server" Text="Eliminar" CssClass="btn btn-eliminar-dg"
                                CommandName="EliminarDG" CommandArgument='<%# Eval("IdProductoDG") %>' CausesValidation="false"
                                OnClientClick="return confirm('¿Está segura de que desea eliminar este producto? Esta acción no se puede deshacer.');" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </div>
    </section>
</asp:Content>
