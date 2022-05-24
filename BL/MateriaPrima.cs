using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class MateriaPrima
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();

            try
            {
                using (DL.ManufacturasEntities context = new DL.ManufacturasEntities())
                {
                    var objMateriaPrima = (from obj in context.MateriaPrimas
                                           select obj).ToList();

                    if (objMateriaPrima != null)
                    {
                        result.Objects = new List<Object>();
                        foreach (var obj in objMateriaPrima)
                        {
                            ML.MateriaPrima materiaPrima = new ML.MateriaPrima();
                            materiaPrima.IdMateriaPrima = obj.IdMateriaPrima;
                            materiaPrima.Nombre = obj.Nombre;
                            materiaPrima.Precio = (decimal)obj.Precio;


                            result.Objects.Add(materiaPrima);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener materia prima";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }

            return result;

        }
    }
}
