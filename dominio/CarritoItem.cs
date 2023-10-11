using dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TP_WEB_EQUIPO_18
{
    /*La clase carrito va a manejar una lista de artículos que serán agregados mediante session*/
    public class CarritoItem
    {
        public int ID { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
    }

}