<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerCarrito.aspx.cs" Inherits="TP_WEB_EQUIPO_18.VerCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Carrito de compras</h1>

    <%--titulo imagen y boton por si no hay objetos en el carrito--%>
    <%if(carrito.Count() == 0)
      {%>
        <h1 id="empeza_el_carrito" runat="server">¡Empieza un carrito de compras!</h1>
        <svg xmlns="http://www.w3.org/2000/svg" width="100" height="100" fill="currentColor" class="bi bi-bag-x-fill" viewBox="0 0 16 16">
            <path fill-rule="evenodd" d="M10.5 3.5a2.5 2.5 0 0 0-5 0V4h5v-.5zm1 0V4H15v10a2 2 0 0 1-2 2H3a2 2 0 0 1-2-2V4h3.5v-.5a3.5 3.5 0 1 1 7 0zM6.854 8.146a.5.5 0 1 0-.708.708L7.293 10l-1.147 1.146a.5.5 0 0 0 .708.708L8 10.707l1.146 1.147a.5.5 0 0 0 .708-.708L8.707 10l1.147-1.146a.5.5 0 0 0-.708-.708L8 9.293 6.854 8.146z" />
        </svg>
        <asp:Button ID="btnRedirigir_default" Cssclass="btn btn-primary" runat="server" OnClick="btnRedirigir_default_Click" Text="Descubrir Productos" />
    <%} %>

    <ol class="list-group list-group-numbered">

        <%foreach (TP_WEB_EQUIPO_18.CarritoItem item in carrito)
            {%>
                <li class="list-group-item d-flex justify-content-between align-items-start">
                    <div class="ms-2 me-auto">
                        <div class="fw-bold"><%=item.Nombre%></div>
                        <%=item.Precio %>
                    </div>
                    <span class="badge bg-primary rounded-pill"><%=item.Cantidad %></span>
                </li>
           <% } %>
    </ol>


    <asp:Label ID="lblCant_total_articulos" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblTotal_items" runat="server" Text="Label"></asp:Label>
    <br />
    <asp:Label ID="lblprecio_total" runat="server" Text="Label"></asp:Label>


</asp:Content>
