using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Producto
    {
        public int IdProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public ML.MateriaPrima MateriaPrima { get; set; }
        public List<object> MateriasPrima { get; set; }
        public List<object> Productos { get; set; }

    }
}
