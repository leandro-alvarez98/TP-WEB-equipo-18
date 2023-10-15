using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TP_WEB_EQUIPO_18
{
    public partial class Compra_realizada : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRedirigir_default_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx");
        }
    }
}