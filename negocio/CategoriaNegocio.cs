using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class CategoriaNegocio
    {
        public List<Categoria> listar()
        {
            List<Categoria> lista = new List<Categoria>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.setConsulta("Select Id, Descripcion From CATEGORIAS");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Categoria categoria_Actual = new Categoria();
                    categoria_Actual.Id = (int)datos.Lector["Id"];
                    categoria_Actual.Descripcion = (string)datos.Lector["Descripcion"];

                    lista.Add(categoria_Actual);
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

        public List<Marca> ObtenerMarcasPorCategoria(string categoriaId)
        {
            List<Marca> marcas = new List<Marca>();
            AccesoDatos datos = new AccesoDatos();

            try
            {
                string consulta = "SELECT Id, Descripcion FROM MARCAS";

                datos.setConsulta(consulta);

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Marca marcaActual = new Marca();
                    marcaActual.Id = (int)datos.Lector["Id"];
                    marcaActual.Descripcion = (string)datos.Lector["Descripcion"];

                    marcas.Add(marcaActual);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.cerrarConexion();
            }

            return marcas;
        }
    }
}