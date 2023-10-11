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
        public List<Articulo> Lista_carrito;
        public Articulo articulo = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (articulo != null)
            {
                articulo = (Articulo)Session["articulo"];
                Lista_carrito.Add(articulo);
                //aca habria que ver como cargar la drop down list  con el articulo 
                
            }else
            {
                DropDownList1.Text = "hola";
            }
           
        }
    }
}
