using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                    StringBuilder Card_Imagen = new StringBuilder();
                    Card_Imagen.Append("<div class='row'>");

                    foreach (var articulo in listaArticulos)
                    {
                        // Obtener la primera URL de imagen para el artículo
                        string primeraUrlImagen = articulo.Imagenes.FirstOrDefault();

                        if (!string.IsNullOrEmpty(primeraUrlImagen))
                        {
                            // Crear una tarjeta (Card) para cada artículo con clases responsivas
                            Card_Imagen.Append("<div class='col-md-4 col-sm-6 mb-4'>"); // Define el ancho de la tarjeta en diferentes tamaños de pantalla
                            Card_Imagen.Append("<div class='card' style='width: 100%;'>");

                            // Aplicar la clase img-reducida a la imagen para reducir su tamaño al 50%
                            Card_Imagen .AppendFormat("<img src='{0}' class='card-img-top' alt='Imagen del artículo'>", primeraUrlImagen);

                            Card_Imagen.Append("<div class='card-body'>");
                            Card_Imagen.AppendFormat("<h5 class='card-title'>{0}</h5>", articulo.Nombre);
                            Card_Imagen.AppendFormat("<p class='card-text'>{0}</p>", articulo.Descripcion);
                            Card_Imagen.Append("</div></div></div>");
                        }
                    }


                    Card_Imagen.Append("</div>");

                    // Agregar las tarjetas al contenedor
                    contenedorArticulos.InnerHtml = Card_Imagen.ToString();
                }
                else
                {
                    // Manejo de errores o mensaje de que no hay artículos disponibles.
                }
            }
        }

    }
}