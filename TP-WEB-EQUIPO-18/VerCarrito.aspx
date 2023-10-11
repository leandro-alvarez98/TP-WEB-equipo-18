<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="VerCarrito.aspx.cs" Inherits="TP_WEB_EQUIPO_18.VerCarrito" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1>Carrito de compras</h1>
  

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
