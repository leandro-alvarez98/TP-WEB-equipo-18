<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_WEB_EQUIPO_18.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>ComprasWeb (?</h1>
    <p>Esta es la página principal del webform.</p>

    <div class="row row-cols-1 row-cols-md-3 g-4">

    <%
        foreach(dominio.Articulo articulo in listaArticulos)
        {
    %>
          <div class="col">
            <div class="card">
              <img src="<%= articulo.Imagenes[0] %>" class="card-img-top" alt="...">
              <div class="card-body">
                <h5 class="card-title"><%= articulo.Nombre %></h5>
                <p class="card-text"><%= articulo.Descripcion %></p>
                <a href="DetalleArticulo.aspx?Id=<%: articulo.ID %>"> Ver articulo </a>
              </div>
            </div>
          </div>
    <% }%>

    </div>
</asp:Content>
