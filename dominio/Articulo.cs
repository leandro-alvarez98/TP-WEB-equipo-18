using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Articulo
    {
        public int ID {  get; set; }
        public String Codigo { get; set; }
        public String Nombre { get; set; }

        [DisplayName("Descripción")]
        public String Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal Precio { get; set; }
        public Imagen Imagen { get; set; }

        public List<String> Imagenes;

        public int id_a_incrementar { get; set; }   
    }
}
