using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using negocio;
using dominio;

namespace TP_WEB_EQUIPO_18
{
    public partial class Formulario_web1 : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        private void CargarComponentes()
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.Listar_con_SP();
                AgruparImagenes();
                EliminarRepetidos();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }
        private List<Articulo> EncontrarRepetidos()
        {
            var articulosAgregados = new HashSet<int>();
            List<Articulo> repetidos = new List<Articulo>();
            foreach (Articulo articulo in listaArticulos)
            {
                if (!articulosAgregados.Contains(articulo.ID))
                {
                    articulosAgregados.Add(articulo.ID);
                }
                else
                {
                    repetidos.Add(articulo);
                }
            }
            return repetidos;
        }
        private void AgruparImagenes()
        {
            List<Articulo> repetidos = EncontrarRepetidos();
            foreach (Articulo articulo in listaArticulos)
            {
                foreach (Articulo repetido in repetidos)
                {
                    if (repetido.ID == articulo.ID)
                    {
                        articulo.Imagenes.Add(repetido.Imagenes[0]);
                    }
                }
            }
        }
        private void EliminarRepetidos()
        {
            List<Articulo> repetidos = EncontrarRepetidos();
            foreach (Articulo repetido in repetidos)
            {
                listaArticulos.Remove(repetido);
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                CargarComponentes();

                CategoriaNegocio negocio = new CategoriaNegocio();
                List<Categoria> categorias = negocio.listar();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataBind();
                //CargarMarcas();
            }



        }

        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Crear una instancia de tu clase CategoriaNegocio
            CategoriaNegocio negocio = new CategoriaNegocio();

            // Obtener la categoría seleccionada
            string categoriaSeleccionada = ddlCategoria.SelectedItem.Value;

            // Obtener las marcas correspondientes a la categoría seleccionada
            List<Marca> marcas = negocio.ObtenerMarcasPorCategoria(categoriaSeleccionada);

            // Configurar el DropDownList de Marcas
            ddlMarcas.DataTextField = "Descripcion";
            ddlMarcas.DataValueField = "Id";
            ddlMarcas.DataSource = marcas;
            ddlMarcas.DataBind();
        }
        protected void btnAceptar_Click(object sender, EventArgs e)
        {
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
        }


    }
}