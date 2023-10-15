<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TP_WEB_EQUIPO_18.Formulario_web1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <h1> ComprasWeb </h1>
    <h4>  Tu destino para descubrir, elegir y comprar 
        <img src="Imagenes/icons8-me-gusta-30.png" />
    </h4>
    <br />
     <%--FILTRADO--%> 
    <div class="mb-3">
        <h5>
            <label for="txtCategoria" class="form-label">Categoria</label>
        </h5>
        <asp:DropDownList ID="ddlCategoria" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged"></asp:DropDownList>
    </div>

    <div class="mb-3">
        <h5>
            <label for="txtMarca" class="form-label">Marca</label>
        </h5>
        <asp:DropDownList ID="ddlMarcas" CssClass="form-select" runat="server" OnSelectedIndexChanged="ddlMarcas_SelectedIndexChanged"></asp:DropDownList>
    </div>

    <asp:Button ID="btnFiltrar" runat="server" Text="Filtrar" OnClick="btnFiltrar_Click" CssClass="btn btn-primary" />
    <asp:Button ID="btnLimpiarFiltro" runat="server" Text="Limpiar filtro" OnClick="btnLimpiarFiltro_Click" CssClass="btn btn-primary" />
    <hr />
    <div class="row row-cols-1 row-cols-md-3 g-4">

        <%-- Decide si mostrar una lista filtrada o la lista completa --%> 
        <% if (mostrarFiltrado)
            {
                if (listaFiltrada.Count > 0 && listaFiltrada != null)
                {
                    foreach (dominio.Articulo articulo in listaFiltrada)
                    {
                    %>
                    <div class="col">
                        <div class="card">
                            <img src="<%= articulo.Imagenes[0] %>" class="card-img-top" alt="...">
                            <div class="card-body">
                                <h5 class="card-title"><%= articulo.Nombre %></h5>
                                <p class="card-text"><%= articulo.Descripcion %></p>
                                <a href="DetalleArticulo.aspx?Id=<%: articulo.ID %>">Ver artículo </a>
                            </div>
                        </div>
                    </div>
                 <% }
                }
                else
                {
                    %>
                    <h1>No hay artículos filtrados.</h1>
                    <%
                }
        %>
        <% }
            else
            {  
                if (listaArticulos.Count > 0 && listaArticulos != null)
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
                                        <a href="DetalleArticulo.aspx?Id=<%: articulo.ID %>">Ver articulo </a>
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
                    <h1>No hay artículos disponibles.</h1>
                    <%
                }
            }
        %>
    </div>

</asp:Content>
