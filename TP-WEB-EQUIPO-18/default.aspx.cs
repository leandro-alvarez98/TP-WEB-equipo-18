using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace TP_WEB_EQUIPO_18
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        private List<Articulo> listaArticulos;
        private void cargar_componentes()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.listar();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                cargar_componentes();
                // Verificamos si la lista tiene al menos una URL de imagen.
                if (listaArticulos.Count > 0)
                {
                    // Aquí seleccionamos la primera URL de la lista.
                    string urlImagen =listaArticulos[0].Imagenes[0];
                    imgMostrar.ImageUrl = urlImagen;
                }
                else
                {
                    // Manejo de errores o mensaje de que no hay imágenes disponibles.
                }
            }
        }

    }
}