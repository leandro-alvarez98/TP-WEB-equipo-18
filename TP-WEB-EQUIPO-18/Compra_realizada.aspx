<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="Compra_realizada.aspx.cs" Inherits="TP_WEB_EQUIPO_18.Compra_realizada" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <h1> Compra realizada con exito </h1>
    <p>Gracias por su compra, atte: Equipo 18</p>
    <asp:Button ID="btnRedirigir_default" Cssclass="btn btn-primary" runat="server" OnClick="btnRedirigir_default_Click" Text="Descubrir mas Productos" />

</asp:Content>
