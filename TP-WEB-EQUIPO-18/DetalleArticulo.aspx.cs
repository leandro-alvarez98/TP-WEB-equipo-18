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
        public Articulo articulo = null;

        private Articulo Cargar_articulo(int id)
        {
            ArticuloNegocio negocio = new ArticuloNegocio();
            try
            {
                listaArticulos = negocio.Listar_con_SP();
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
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                int id_articulo = int.Parse(Request.QueryString["Id"]);
                articulo = Cargar_articulo(id_articulo);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw;
            }


        }
    }
}