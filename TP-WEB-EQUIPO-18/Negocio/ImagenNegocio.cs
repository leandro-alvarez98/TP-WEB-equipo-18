using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_WEB_EQUIPO_18
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
    }
}