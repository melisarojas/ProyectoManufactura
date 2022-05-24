using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Producto
    {
        public static ML.Result GetAll(int IdMateriaPrima)
        {
            ML.Result result = new ML.Result();//para mandARLO PRIMERO NO SERIA ASI COMO SE LOS MOSTRE? si, pero si lo podemos corregir estarai mejor, no crees? si

            try
            {
                using (DL.ManufacturasEntities context = new DL.ManufacturasEntities())
                {
                    List<DL.Producto> objProducto = new List<DL.Producto>(); 

                    if(IdMateriaPrima!= 0)
                    {
                        objProducto = (from obj in context.Productoes
                                           where obj.IdMateriaPrima == IdMateriaPrima
                                           select obj).ToList();
                    }
                    else
                    {
                        objProducto = (from obj in context.Productoes
                                           select obj).ToList();
                    }
                   

                    if (objProducto != null)
                    {
                        result.Objects = new List<Object>();
                        foreach (var obj in objProducto)
                        {
                            ML.Producto producto = new ML.Producto();
                            producto.IdProducto = obj.IdProducto;
                            producto.Nombre = obj.Nombre;
                            producto.Descripcion = obj.Descripcion;
                            producto.Precio = (decimal)obj.Precio;
                            producto.MateriaPrima = new ML.MateriaPrima();
                            producto.MateriaPrima.IdMateriaPrima = obj.IdMateriaPrima.Value;

                            result.Objects.Add(producto);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al obtener los productos";
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

        public static ML.Result Add(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ManufacturasEntities context = new DL.ManufacturasEntities())
                {
                    DL.Producto productoLinq = new DL.Producto();

                    productoLinq.Nombre = producto.Nombre;
                    productoLinq.Descripcion = producto.Descripcion;
                    productoLinq.Precio = producto.Precio;
                    productoLinq.IdMateriaPrima = producto.MateriaPrima.IdMateriaPrima;

                    context.Productoes.Add(productoLinq);

                    int RowsAffected = context.SaveChanges();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Ocurrió un error al agregar un producto";
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

        public static ML.Result GetById(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ManufacturasEntities context = new DL.ManufacturasEntities())
                {
                    var objProducto = (from obj in context.Productoes
                                       where obj.IdProducto == IdProducto
                                       select obj).Single();

                    if (objProducto != null)
                    {
                        ML.Producto producto = new ML.Producto();

                        producto.IdProducto = objProducto.IdProducto;
                        producto.Nombre = objProducto.Nombre;
                        producto.Descripcion = objProducto.Descripcion;
                        producto.Precio = (decimal)objProducto.Precio;
                        producto.MateriaPrima = new ML.MateriaPrima();
                        producto.MateriaPrima.IdMateriaPrima = objProducto.IdMateriaPrima.Value;

                        result.Object = producto;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se econtro el producto";
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
        public static ML.Result Update(ML.Producto producto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ManufacturasEntities context = new DL.ManufacturasEntities())
                {
                    var productoLinq = (from obj in context.Productoes
                                        where obj.IdProducto == producto.IdProducto
                                        select obj).FirstOrDefault();

                    if (productoLinq != null)
                    {
                        productoLinq.Nombre = producto.Nombre;
                        productoLinq.Descripcion = producto.Descripcion;
                        productoLinq.Precio = producto.Precio;
                        productoLinq.IdMateriaPrima = producto.MateriaPrima.IdMateriaPrima;

                        int RowsAffected = context.SaveChanges();

                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al momento de actualizar el producto";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el producto";
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

        public static ML.Result Delete(int IdProducto)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.ManufacturasEntities context = new DL.ManufacturasEntities())
                {
                    var query = (from itemProducto in context.Productoes
                                 where itemProducto.IdProducto == IdProducto
                                 select itemProducto).Single();

                    context.Productoes.Remove(query);
                    if (query != null)
                    {
                        int RowsAffected = context.SaveChanges();
                        if (RowsAffected > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                            result.ErrorMessage = "Ocurrió un error al momento de borrar el producto";
                        }
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el producto";
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
