<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TP_WEB_EQUIPO_18.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>DETALLE DE ARTÍCULO</h1>
    <p>En ésta página se mostrarán los detalles del artículo + un carrusel con todas las imágenes del mismo</p>

    <% if (articuloSeleccionado != null && articuloSeleccionado.Imagenes.Count > 0)
       {
    %>
           <!-- Carrusel -->
           <div id="carouselExampleFade" class="carousel slide carousel-fade">

               <div class="carousel-inner">

                   <div class="carousel-item active">

                    <img id="imagenCarrusel" data-indice="0" src="<%=articuloSeleccionado.Imagenes[0]%>" class="d-block w-50" alt="...">

                </div>

               </div>

                <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">

                    <span class="carousel-control-prev-icon" aria-hidden="true"></span>

                    <span class="visually-hidden">Previous</span>

                </button>

                <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">

                    <span class="carousel-control-next-icon" aria-hidden="true"></span>

                    <span class="visually-hidden">Next</span>

                </button>

           </div>
    <% }
       else
       { %>
           <img src="https://cdn.icon-icons.com/icons2/3001/PNG/512/default_filetype_file_empty_document_icon_187718.png" class="card-img-top" alt="...">
    <% } %>

    <!--Este código cambia la imágen en base al botón que apretemos -->
    <!--Botón siguiente: -->
    <script>
        //Convierte la lista C# en una lista JavaScript
        var imagenes = <%=ConvertirImagenesAJavaScript()%>;
        console.log(imagenes.length);
        

        document.addEventListener('DOMContentLoaded', function () {
            var imagenCarrusel = document.getElementById('imagenCarrusel');
            var botonSiguiente = document.querySelector('.carousel-control-next');
            var indiceActual = 0;

            botonSiguiente.addEventListener('click', function () {
                if (indiceActual < imagenes.length - 1) {
                    indiceActual++;
                } else {
                    indiceActual = 0; // Vuelve al principio cuando alcanza el final
                }

                // Actualiza el atributo data-indice
                imagenCarrusel.setAttribute('data-indice', indiceActual);

                // Actualiza el src de la imagen del carrusel con la nueva URL
                imagenCarrusel.src = imagenes[indiceActual];
            });
        });
    </script>
    <!--Botón anterior: -->
    <script>
        document.addEventListener('DOMContentLoaded', function () {
            var imagenCarrusel = document.getElementById('imagenCarrusel');
            var botonPrevio = document.querySelector('.carousel-control-prev');
            var indiceActual = 0;

            botonPrevio.addEventListener('click', function () {
                if (indiceActual > 0) {
                    indiceActual--;
                } else {
                    indiceActual = imagenes.length - 1; // Vuelve al final cuando estás en la primera imagen
                }

                // Actualiza el atributo data-indice
                imagenCarrusel.setAttribute('data-indice', indiceActual);

                // Actualiza el src de la imagen del carrusel con la nueva URL
                imagenCarrusel.src = imagenes[indiceActual];
            });
        });

    </script>


</asp:Content>
