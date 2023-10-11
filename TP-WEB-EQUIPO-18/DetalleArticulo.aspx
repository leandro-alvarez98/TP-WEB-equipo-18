<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="DetalleArticulo.aspx.cs" Inherits="TP_WEB_EQUIPO_18.Formulario_web11" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>DETALLE DEL ARTÍCULO</h1>

    <asp:Button ID="agregar_a_carrito" runat="server" Text="Agregar a Carrito" OnClick="btnAgregar_Click" />

    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>

    <!-- Detalles del artículo -->
    <div class="container">
        <div class="row">
            <div class="col-md-4">
                <div class="card border-dark mb-3">
                    <div class="card-header">#<%= articuloSeleccionado.Codigo %> </div>
                    <div class="card-body">
                        <h5 class="card-title"><%=articuloSeleccionado.Nombre %></h5>
                        <p class="card-text"><%=articuloSeleccionado.Descripcion %></p>
                        <p class="card-text">Precio: $<%=articuloSeleccionado.Precio %></p>
                        <p class="card-text">Marca: <%=articuloSeleccionado.Marca %></p>
                        <p class="card-text">Categoria: <%=articuloSeleccionado.Categoria %></p>
                    </div>
                </div>
            </div>

     <!-- Carrusel con imágenes -->
            <% if (articuloSeleccionado != null && articuloSeleccionado.Imagenes.Count > 0)
                {
            %>
            <div class="col-md-8">
                <div id="carouselExampleFade" class="carousel slide carousel-fade">

                    <div class="carousel-inner">
                        <!-- Recorre todas las imágenes -->
                        <% for (int i = 0; i < articuloSeleccionado.Imagenes.Count; i++)
                            {
                                //Url de la imágen actual
                                string urlimagen = articuloSeleccionado.Imagenes[i];
                                //Comprueba si la imágen actual es la primera en la lista
                                bool esActiva = (i == 0);
                        %>
                        <div class="carousel-item <%= esActiva ? "active" : "" %>">
                            <img id="imagenCarrusel" data-indice="<%= i %>" src="<%= urlimagen %>" class="d-block mx-auto" alt="...">
                        </div>
                        <% } %>
                    </div>
                    <!-- Botón imagen previa -->
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
                        <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Previous</span>
                    </button>
                    <!-- Botón imagen siguiente -->
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
                        <span class="carousel-control-next-icon" aria-hidden="true"></span>
                        <span class="visually-hidden">Next</span>
                    </button>

                </div>
            </div>
        </div>
    </div>
    <% }
    else
    { %>
       <img src="https://sportshub.cbsistatic.com/i/2022/08/20/184ad631-2e9c-419c-bf75-9c288db1610e/rick-astley-never-gonna-give-you-up-meme.jpg" class="card-img-top" alt="...">
    <% } %>

    <!--Este código cambia la imágen en base al botón que apretemos -->
    <!--Botón siguiente: -->
    <script>
        //Convierte la lista C# en una lista JavaScript
        let imagenes = <%=ConvertirImagenesAJavaScript()%>;
        document.addEventListener('DOMContentLoaded', function ()
        {
            let imagenCarrusel = document.getElementById('imagenCarrusel');
            let botonSiguiente = document.querySelector('.carousel-control-next');
            let indiceActual = 0;

            botonSiguiente.addEventListener('click', function ()
            {
                if (indiceActual < imagenes.length - 1)
                {
                    indiceActual++;
                } else
                {
                    indiceActual = 0; // Vuelve al principio cuando alcanza el final
                }

                // Actualiza el atributo data-indice
                imagenCarrusel.setAttribute('data-indice', indiceActual);

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

                imagenCarrusel.src = imagenes[indiceActual];
            });
        });
    </script>


</asp:Content>
