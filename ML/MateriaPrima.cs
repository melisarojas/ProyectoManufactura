using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class MateriaPrima
    {
        public int IdMateriaPrima { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public List<object> MateriasPrima { get; set; }
    }
}
