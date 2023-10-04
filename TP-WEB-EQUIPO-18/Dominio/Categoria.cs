using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_WEB_EQUIPO_18
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}