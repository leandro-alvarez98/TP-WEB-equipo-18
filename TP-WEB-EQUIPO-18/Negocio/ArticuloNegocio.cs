using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Windows.Forms;

namespace TP_WEB_EQUIPO_18
{
    public class ArticuloNegocio
    {
        public List<Articulo> listar()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca as marca, a.IdCategoria as categoria, a.Precio,m.Descripcion as mdescripcion,i.ImagenUrl as link,c.Descripcion as cdescripcion FROM ARTICULOS a LEFT JOIN MARCAS m ON m.Id = a.IdMarca LEFT JOIN IMAGENES i ON i.IdArticulo = a.Id LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Articulo objetoArticulo = new Articulo();

                    objetoArticulo.ID = (int)datos.Lector["Id"];

                    if (!(datos.Lector["Codigo"] is DBNull))
                    {
                        objetoArticulo.Codigo = (string)datos.Lector["Codigo"];
                    }
                    if (!(datos.Lector["Nombre"] is DBNull))
                    {
                        objetoArticulo.Nombre = (string)datos.Lector["Nombre"];
                    }
                    if (!(datos.Lector["Descripcion"] is DBNull))
                    {
                        objetoArticulo.Descripcion = (string)datos.Lector["Descripcion"];
                    }

                    objetoArticulo.Marca = new Marca();
                    if (!(datos.Lector["marca"] is DBNull))
                    {
                        objetoArticulo.Marca.Id = (int)datos.Lector["marca"];
                        objetoArticulo.Marca.Descripcion = (string)datos.Lector["mdescripcion"];
                    }

                    objetoArticulo.Categoria = new Categoria();
                    if (!(datos.Lector["categoria"] is DBNull))
                    {
                        objetoArticulo.Categoria.Id = (int)datos.Lector["categoria"];
                    }
                    if (!(datos.Lector["cdescripcion"] is DBNull))
                    {
                        objetoArticulo.Categoria.Descripcion = (string)datos.Lector["cdescripcion"];
                    }
                    else
                    {
                        objetoArticulo.Categoria.Descripcion = "-";
                    }

                    if (!(datos.Lector["Precio"] is DBNull))
                        objetoArticulo.Precio = (decimal)datos.Lector["Precio"];

                    //objetoArticulo.Imagen = new Imagen();
                    objetoArticulo.Imagenes = new List<String>();
                    if (!(datos.Lector["link"] is DBNull))
                    {
                        //objetoArticulo.Imagen.ImagenUrl = (string)datos.Lector["link"];
                        objetoArticulo.Imagenes.Add((string)datos.Lector["link"]);
                    }
                    else
                    {
                        objetoArticulo.Imagenes.Add("Sin imagen");
                    }

                    lista.Add(objetoArticulo);
                }
                return lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }
        }
    }

}