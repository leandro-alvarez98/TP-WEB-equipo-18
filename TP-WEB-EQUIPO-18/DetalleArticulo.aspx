<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TP_WEB_EQUIPO_18.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>DETALLE DE ARTÍCULO</h1>
    <p>En ésta página se mostrarán los detalles del artículo + un carrusel con todas las imágenes del mismo</p>

    <%if(articulo != null)
            { %>
          <%--  carousel--%>
                <div id="carouselExampleFade" class="carousel slide carousel-fade">

                        <%int i = 0; %>
                        <%foreach (var urlimagen in articulo.Imagenes)
                            {%>
                         <div class="carousel-inner">
                                <div class="carousel-item active">
                                    <img src="<%= articulo.Imagenes[i] %>" class="d-block w-50" alt="...">
                                </div>
                              </div>
                            <%i++; %>
                          <%} %>

                   
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>
                </div>
   <% } else
         {%>
            <img src="https://cdn.icon-icons.com/icons2/3001/PNG/512/default_filetype_file_empty_document_icon_187718.png" class="card-img-top" alt="...">
       <%}%>
  


</asp:Content>
