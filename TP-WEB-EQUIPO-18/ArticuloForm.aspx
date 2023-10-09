<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_WEB_EQUIPO_18.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div class="row">
        <div class="col-6">
            <div class="mb-3">
                <label for="txtId" class="form-label">Id</label>
                <asp:TextBox runat="server" ID="txtId" CssClass="form-control" />
            </div>
            <div class="mb-3">
                <label for="txtCodigo" class="form-label">Codigo</label>
                <asp:TextBox runat="server" ID="txtCodigo" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtNombre" class="form-label">Nombre</label>
                <asp:TextBox runat="server" ID="txtNombre" CssClass="form-control"/>
            </div>
            <div class="mb-3">
                <label for="txtDescripcion" class="form-label">Descripcion</label>
                <asp:TextBox runat="server" TextMode="Multiline" ID="txtDescripcion" CssClass="form-control"/>
            </div> 
            <div class="mb-3">
                <label for="txtMarca" class="form-label">Marca</label>
                <asp:DropDownList ID="ddlMarcas" ccclass="form-select" runat="server"> </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtCategoria" class="form-label">Categoria</label>
                <asp:DropDownList ID="ddlCategoria" CssClass="form-select"  runat="server"> </asp:DropDownList>
            </div>
            <div class="mb-3">
                <label for="txtPrecio" class="form-label">Precio</label>
                <asp:TextBox runat="server" ID="txtPrecio" CssClass="form-control"/>
            </div>   
            <div class="mb-3">
                <label for="txtImagen" class="form-label">Imagen</label>
                <asp:FileUpload runat="server" ID="txtImagen" CssClass="form-control" />
            </div>
            <%--  <div class="mb-3">
                <asp:Button Text="Aceptar" ID="btnAceptar" ccclass="btn btn-primary" OnClick="btnAceptar_Click" runat="server"/>
                <a href="Default.aspx">Cancelar</a>

            </div>
                --%>

       

        </div>
    </div>



</asp:Content>