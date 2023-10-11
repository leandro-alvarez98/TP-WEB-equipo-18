using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_WEB_EQUIPO_18
{
    public partial class MasterPage : System.Web.UI.MasterPage
    {
        public Articulo articulo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Carrito"] == null)
            {
                Session["Carrito"] = new List<CarritoItem>();
            }
            if(!IsPostBack)
            {
                CargarArticulosEnCarrito();
            }
        }

        public void CargarArticulosEnCarrito()
        {
            if (Session["Carrito"] != null)
            {
                List<CarritoItem> carrito = (List<CarritoItem>)Session["Carrito"];

                // Primero limpia la lista
                DropDownList1.Items.Clear();

                // Luego agrega los artículos de la lista a la DropDownList
                foreach (CarritoItem item in carrito)
                {
                    ListItem listItem = new ListItem($"{item.Nombre} - ${item.Precio} ({item.Cantidad} en carrito)", item.IdArticulo.ToString());
                    DropDownList1.Items.Add(listItem);
                }
            }
        }


    }
}
