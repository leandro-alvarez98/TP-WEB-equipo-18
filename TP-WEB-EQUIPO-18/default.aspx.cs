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
        public List<Articulo> listaFiltrada { get; set; }
        private string categoriaSeleccionada;
        private string marcaSeleccionada;
        protected bool mostrarFiltrado = false;

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
            //Carga las listas de artículos a mostrar
            CargarComponentes();
            if(!IsPostBack)
            {
                //Carga las DropDownList
                CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
                List<Categoria> categorias = categoriaNegocio.listar();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataSource = categorias;
                ddlCategoria.DataBind();
                //ddlCategoria.Items.Insert(0, new ListItem("<Selecciona Categoria>", ""));
                ddlCategoria.Items.Insert(0, new ListItem("<Selecciona Categoria>", string.Empty));


                MarcaNegocio marcaNegocio = new MarcaNegocio();
                List<Marca> marcas = marcaNegocio.listar();
                ddlMarcas.DataTextField = "Descripcion";
                ddlMarcas.DataValueField = "Id";
                ddlMarcas.DataSource = marcas;
                ddlMarcas.DataBind();
                //ddlMarcas.Items.Insert(0, new ListItem("<Selecciona Marca>", ""));
                ddlMarcas.Items.Insert(0, new ListItem("<Selecciona Marca>", string.Empty));

            }
        }
        
        protected void ddlCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            categoriaSeleccionada = ddlCategoria.SelectedValue;
        }
        protected void ddlMarcas_SelectedIndexChanged(object sender, EventArgs e) { 
            marcaSeleccionada = ddlMarcas.SelectedValue;
        }
        protected void btnLimpiarFiltro_Click(object sender, EventArgs e) {
            ddlCategoria.SelectedIndex = 0;
            ddlMarcas.SelectedIndex = 0;
        }
        protected void btnFiltrar_Click(object sender, EventArgs e)
        {
            listaFiltrada = new List<Articulo>();

            try
            {
                //Lista filtrada solo por Marcas
                if (categoriaSeleccionada == null && marcaSeleccionada != null)
                {
                    foreach (Articulo item in listaArticulos)
                    {
                        if (item.Marca.Id == int.Parse(marcaSeleccionada))
                        {
                            listaFiltrada.Add(item);
                        }
                    }
                    mostrarFiltrado = true;
                }

                //Lista filtrada solo por Categorias
                else if (categoriaSeleccionada != null && marcaSeleccionada == null)
                {
                    foreach (Articulo item in listaArticulos)
                    {
                        if (item.Categoria.Id == int.Parse(categoriaSeleccionada))
                        {
                            listaFiltrada.Add(item);
                        }
                    }
                    mostrarFiltrado = true;
                }
                //Lista filtrada por ambas condiciones
                else if (categoriaSeleccionada != null && marcaSeleccionada != null)
                {
                    foreach (Articulo item in listaArticulos)
                    {
                        if (item.Categoria.Id == int.Parse(categoriaSeleccionada) && item.Marca.Id == int.Parse(marcaSeleccionada))
                        {
                            listaFiltrada.Add(item);
                        }
                    }
                    mostrarFiltrado = true;
                }
                else if (string.IsNullOrEmpty(categoriaSeleccionada) && string.IsNullOrEmpty(marcaSeleccionada)) {
                    //MessageBox.Show("No se han seleccionado filtros.");
                    mostrarFiltrado = false;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Hubo un error, por favor asegurese de limpiar los filtros! -Soporte del equipo 18 ;)");
            }
        }
    }
}