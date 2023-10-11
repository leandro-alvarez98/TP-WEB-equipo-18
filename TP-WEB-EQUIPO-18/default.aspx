<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_WEB_EQUIPO_18.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <h1>ComprasWeb (?</h1>
    <p>Esta es la página principal del webform.</p>
     <%--FILTRADO--%> 

    <div class="mb-3">
        <label for="txtCategoria" class="form-label">Categoria</label>
        <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged" AutoPostBack="true" ></asp:DropDownList>
    </div>
    <div class="mb-3">
        <label for="txtMarca" class="form-label">Marca</label>
        <asp:DropDownList ID="ddlMarcas" ccclass="form-select" runat="server" ></asp:DropDownList>
    </div>
    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnAgregar_Click" />


        <div class="row row-cols-1 row-cols-md-3 g-4">
        <% if (listaArticulos.Count > 0 && listaArticulos!= null )
           {
               //Hashset es como un diccionario, no almacena valores repetidos.
               var articulosAgregados = new HashSet<int>();

               foreach (dominio.Articulo articulo in listaArticulos)
               {
                    //Aca comprueba si ya se agregó ese ID, o sea si el artículo ya fue cargado en las Cards
                   if (!articulosAgregados.Contains(articulo.ID))
                   {
                       //Como el artículo no está agregado, lo agrega así no se repite.
                       articulosAgregados.Add(articulo.ID);
         %>
                       <div class="col">
                           <div class="card">
                               <img src="<%= articulo.Imagenes[0] %>" class="card-img-top" alt="...">
                               <div class="card-body">
                                   <h5 class="card-title"><%= articulo.Nombre %></h5>
                                   <p class="card-text"><%= articulo.Descripcion %></p>
                                   <a href="DetalleArticulo.aspx?Id=<%: articulo.ID %>"> Ver articulo </a>
                                   <asp:Button ID="btnAceptar" runat="server" Text="Ver Articulo" OnClick="btnAceptar_Click"/>
                                   <asp:Button ID="agregar_a_carrito" runat="server" Text="Agregar a Carrito" OnClick="btnAgregar_Click" />
                               </div>
                           </div>
                       </div>
         <%
                   }
               }
           }
           else
           {
         %>
               <p>No hay artículos disponibles.</p>
         <%
           }
         %>
    </div>

</asp:Content>
