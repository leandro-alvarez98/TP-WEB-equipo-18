using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace TP_WEB_EQUIPO_18
{
    public partial class VerCarrito : System.Web.UI.Page
    {
        public int cantidad_items;
        public int cantidad_total_articulos = 0;
        public decimal cantidad_total_a_pagar = 0;
        public List<CarritoItem> carrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Carrito"] != null)
            {
                    carrito = (List<CarritoItem>)Session["Carrito"];
                actualizarLabels();
                
            }
            if (!IsPostBack)
            {
                Repetidor.DataSource = carrito;
                Repetidor.DataBind();
            }
        }
        protected void btnRedirigir_default_Click(object sender, EventArgs e)
        {
            Response.Redirect("default.aspx", false);
        }
        protected void EliminarItemDelCarrito(int ID)
        {
            CarritoItem itemAEliminar = carrito.FirstOrDefault(item => item.ID == ID);

            if (itemAEliminar != null)
            {
                carrito.Remove(itemAEliminar);
            }
            Session["Carrito"] = carrito;

            MasterPage master = (MasterPage)this.Master;
            master.CargarArticulosEnCarrito();
            actualizarLabels();

        }
        protected void btnEliminar_Command(object sender, CommandEventArgs e)
        {
            String idArticulo = ((System.Web.UI.WebControls.Button)sender).CommandArgument;
            int ID = int.Parse(idArticulo);
            EliminarItemDelCarrito(ID);
        }
        protected void actualizarLabels()
        {
            cantidad_items = 0;
            cantidad_total_articulos = 0;
            cantidad_total_a_pagar = 0;

            if(carrito != null)
            {
                cantidad_items = carrito.Count();

                foreach (CarritoItem item in carrito)
                {
                    cantidad_total_articulos += item.Cantidad;
                    cantidad_total_a_pagar += item.Cantidad * item.Precio;
                }
            }
            lblCant_total_articulos.Text = " Total de articulos " + cantidad_total_articulos.ToString();
            lblTotal_items.Text = " Total items dentro de la lista " + cantidad_items.ToString();
            lblprecio_total.Text = " Total a pagar $" + cantidad_total_a_pagar.ToString();
        }
    }
}