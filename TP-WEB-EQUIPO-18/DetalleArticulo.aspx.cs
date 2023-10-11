using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Windows.Forms;

namespace TP_WEB_EQUIPO_18
{
    public partial class Formulario_web11 : System.Web.UI.Page
    {
        public List<Articulo> listaArticulos { get; set; }
        public Articulo articuloSeleccionado = null;
        public int id;
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
        private Articulo CargarComponentes()
        {
            listaArticulos = new List<Articulo>();
            
            ArticuloNegocio negocio = new ArticuloNegocio();
            if (Request.QueryString["Id"] != null)
            {
                id = int.Parse(Request.QueryString["Id"]);
            }

            try
            {
                listaArticulos = negocio.Listar_con_SP();
                AgruparImagenes();
                EliminarRepetidos();

                foreach (var articulo in listaArticulos)
                {
                    if (id == articulo.ID)
                    {
                        return articulo;
                    }
                }
                return null;
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                 
                throw ex;
            }
        }

        public string ConvertirImagenesAJavaScript()
        {
            List<string> imagenes = new List<string>();

            imagenes = articuloSeleccionado.Imagenes;

            if (imagenes != null && imagenes.Count > 0)
            {
                return "[" + string.Join(", ", imagenes.Select(img => "\"" + img + "\"")) + "]";
            }
            else
            {
                return "[]";
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                articuloSeleccionado = CargarComponentes();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            int ID = articuloSeleccionado.ID;
            string NOMBRE = articuloSeleccionado.Nombre; 
            decimal PRECIO = articuloSeleccionado.Precio; 

            // Verifica si el artículo ya está en el carrito
            List<CarritoItem> carrito = (List<CarritoItem>)Session["Carrito"];
            //Busca un elemento dentro de la lista donde cohincida el Id para encontrar repetidos.
            CarritoItem itemExistente = carrito.FirstOrDefault(item => item.IdArticulo == ID);
            //En caso de que hayan repetidos, itemExistente queda distinto a null, por lo que solo se incrementa la cantidad
            if (itemExistente != null)
            {
                // Si el artículo ya está en el carrito, incrementa la cantidad
                itemExistente.Cantidad += 1;
            }
            else
            {
                // Si devuelve null, el item no se encuentra en la lista, por lo que crea uno.
                CarritoItem nuevoItem = new CarritoItem();
                nuevoItem.IdArticulo = ID;
                nuevoItem.Nombre = NOMBRE;
                nuevoItem.Precio = PRECIO;
                nuevoItem.Cantidad = 1;
                carrito.Add(nuevoItem);
            }

            // Actualiza el carrito con cada click
            Session["Carrito"] = carrito;

            MasterPage master = (MasterPage)this.Master;
            master.CargarArticulosEnCarrito();
        }
    }
}