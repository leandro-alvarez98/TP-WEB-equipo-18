using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;

namespace TP_WEB_EQUIPO_18
{
    public partial class ArticuloForm : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //aca se habilita la informacion de los desplegables 
        }
        protected void btnAceptar_Click(object sender, EventArgs e) { 
            Articulo articulo = new Articulo();
            /* articulo.Codigo = txtCodigo.Text;
             articulo.Nombre = txtNombre.Text;
             articulo.Descripcion = txtDescripcion.Text;
             articulo.Marca = ddlMarcas.SelectedValue;
             articulo.Categoria = ddlCategoria.SelectedValue;
             articulo.Precio = int.Parse(txtPrecio.Text);
             articulo.Imagen = 
            */

        }
    }
}