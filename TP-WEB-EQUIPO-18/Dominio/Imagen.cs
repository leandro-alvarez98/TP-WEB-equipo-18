using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_WEB_EQUIPO_18
{
    public class Imagen
    {
        public int ID { get; set; }
        public int IdArticulo { get; set; }
        public string ImagenUrl { get; set; }

        public override string ToString()
        {
            return ImagenUrl;
        }
    }
}