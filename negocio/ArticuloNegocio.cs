using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using dominio;
using static System.Windows.Forms.LinkLabel;

namespace negocio
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
                    }else
                    {
                        objetoArticulo.Categoria.Descripcion = "-";
                    }

                    if (!(datos.Lector["Precio"] is DBNull))
                        objetoArticulo.Precio = (decimal)datos.Lector["Precio"];


                    objetoArticulo.Imagenes = new List<String>();

                    objetoArticulo.Imagen = new Imagen();

                    if (!(datos.Lector["link"] is DBNull))
                    {
                        objetoArticulo.Imagen.ImagenUrl = (string)datos.Lector["link"];
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
        public void agregar(Articulo nuevo_articulo)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = listar();

            Articulo articulo_aux = new Articulo();


           articulo_aux = lista.Last();
            

            nuevo_articulo.id_a_incrementar = articulo_aux.ID + 1;

            try
            {
                datos.setConsulta("INSERT INTO ARTICULOS ( Codigo, Nombre, IdMarca, IdCategoria, Precio, Descripcion) VALUES (@Codigo, @Nombre, @Marca, @Categoria, @Precio, @Descripcion) INSERT INTO IMAGENES (IdArticulo, ImagenUrl) VALUES (@IdArticulo, @ImagenUrl)");
                datos.setParametro("@Codigo", nuevo_articulo.Codigo);
                datos.setParametro("@Nombre", nuevo_articulo.Nombre);
                datos.setParametro("@Marca", nuevo_articulo.Marca.Id);
                datos.setParametro("@Categoria", nuevo_articulo.Categoria.Id);
                datos.setParametro("@Precio", nuevo_articulo.Precio);
                datos.setParametro("@Descripcion", nuevo_articulo.Descripcion);

                if(nuevo_articulo.Imagenes.Count > 0)
                {
                    datos.setParametro("@IdArticulo", nuevo_articulo.id_a_incrementar);
                    datos.setParametro("@ImagenUrl", nuevo_articulo.Imagenes[0]);
                }
                else
                {
                    datos.setParametro("@IdArticulo", nuevo_articulo.id_a_incrementar);
                    datos.setParametro("@ImagenUrl", "Sin imagen");
                }
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
        public void Modificar (Articulo articulo) 
        {
            AccesoDatos datos = new AccesoDatos ();
            try
            {
                datos.setConsulta("UPDATE ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion,idMarca = @marca,idCategoria = @categoria ,Precio = @precio where id = @id UPDATE IMAGENES SET ImagenUrl = '" + articulo.Imagen.ImagenUrl + "' where IdArticulo = @id");
                datos.setParametro("@id", articulo.ID);
                datos.setParametro("@codigo", articulo.Codigo);
                datos.setParametro("@nombre", articulo.Nombre);
                datos.setParametro("@descripcion", articulo.Descripcion);
                datos.setParametro("@precio", articulo.Precio);
                datos.setParametro("@marca", articulo.Marca.Id);
                datos.setParametro("@categoria", articulo.Categoria.Id);

                datos.ejecutarLectura();

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
        public void Eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setConsulta("DELETE FROM ARTICULOS WHERE Id = @Id DELETE FROM IMAGENES WHERE IdArticulo = @Id");
                datos.setParametro("@Id", id);
                datos.ejecutarAccion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Articulo> filtrar(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT a.Id, a.Codigo, a.Nombre, a.Descripcion, a.IdMarca as marca, a.IdCategoria as categoria, a.Precio,m.Descripcion as mdescripcion,i.ImagenUrl as link,c.Descripcion as cdescripcion FROM ARTICULOS a LEFT JOIN MARCAS m ON m.Id = a.IdMarca LEFT JOIN IMAGENES i ON i.IdArticulo = a.Id LEFT JOIN CATEGORIAS c ON c.Id = a.IdCategoria WHERE ";
                switch (campo) {

                    case "ID":
                        switch (criterio)
                        {
                            case "Mayor a":
                                consulta += "a.Id > " + filtro;
                                break;
                            case "Menor a":
                                consulta += "a.Id < " + filtro;
                                break;
                            default:
                                consulta += "a.Id = " + filtro;
                                break;
                        }
                        break;

                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "a.Nombre like '" + filtro  + "%' " ;
                                break;
                            case "Termina con":
                                consulta += "a.Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "a.Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    case "Descripcion":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "a.Descripcion like '" + filtro + "%' ";
                                break;
                            case "Termina con":
                                consulta += "a.Descripcion like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "a.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;

                    default:
                        break;
                }


                datos.setConsulta(consulta);

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

                    objetoArticulo.Imagenes = new List<String>();
                    if (!(datos.Lector["link"] is DBNull))
                    {
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

                throw ex;
            }        
        }
        public void resetear_ids()
        {
            AccesoDatos datos = new AccesoDatos();
            datos.setConsulta("DECLARE @UltimoValor INT SELECT @UltimoValor = MAX(Id) FROM Articulos DBCC CHECKIDENT ([Articulos], RESEED, @UltimoValor)");
            datos.ejecutarAccion();
        }
    }    
}
