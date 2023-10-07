using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization.Advanced;
using static System.Net.Mime.MediaTypeNames;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace negocio
{
    public class ImagenNegocio
    {
        public List<Imagen> listar()
        {
            List<Imagen> lista = new List<Imagen>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select Id, IdArticulo, ImagenUrl From IMAGENES");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Imagen imagen_Actual = new Imagen();
                    imagen_Actual.ID = (int)datos.Lector["Id"];
                    imagen_Actual.IdArticulo = (int)datos.Lector["IdArticulo"];
                    imagen_Actual.ImagenUrl = (string)datos.Lector["ImagenUrl"];

                    lista.Add(imagen_Actual);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public void añadir(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("INSERT INTO IMAGENES VALUES(" + articulo.ID + ", '" + articulo.Imagenes.Last() + "')");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
        public bool Tiene_ImagenDefault(Articulo articulo)
        {
            if (articulo.Imagenes.Count > 1)
            {
                if (articulo.Imagenes.First() == "")
                {
                    return true;
                }
            }
            return false;
        }
        public void eliminar_imagen(Articulo articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("DELETE FROM IMAGENES WHERE Id = " + articulo.ID + " AND ImagenUrl = ''");
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }
}
                                          