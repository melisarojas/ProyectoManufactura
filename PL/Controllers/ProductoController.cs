using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class ProductoController : Controller
    {
        // GET: Producto
        [HttpGet]
        public ActionResult GetAll()
        {
            ML.Producto producto = new ML.Producto();
            producto.Productos = new List<object>();
            int IdMateriaPrima = 0;
            producto.MateriaPrima = new ML.MateriaPrima();
            ML.Result resultMateriaPrima = BL.MateriaPrima.GetAll();
            producto.MateriaPrima.MateriasPrima = resultMateriaPrima.Objects;

            using (var client = new HttpClient())
            {
                string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(urlApi);
                var responseTask = client.GetAsync("api/producto/GetAll/" + IdMateriaPrima);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        producto.Productos.Add(resultItemList);

                    }
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al obtener la informacion";
                    return PartialView("Modal");
                }
            }
            return View(producto);
        }

        [HttpPost]
        public ActionResult GetAll(ML.MateriaPrima materiaPrima)
        {
            
            ML.Producto producto = new ML.Producto();
            producto.Productos = new List<object>();

            producto.MateriaPrima = new ML.MateriaPrima();
            producto.MateriaPrima.MateriasPrima = new List<object>();
            ML.Result resultMateriaPrima = BL.MateriaPrima.GetAll();
            producto.MateriaPrima.MateriasPrima = resultMateriaPrima.Objects;
            producto.MateriaPrima.IdMateriaPrima = materiaPrima.IdMateriaPrima;
            
            
            using (var client = new HttpClient())
            {
                string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(urlApi);
                var responseTask = client.GetAsync("api/producto/GetAll/" + producto.MateriaPrima.IdMateriaPrima);
                responseTask.Wait();
                var result = responseTask.Result;

                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();
                    foreach (var resultItem in readTask.Result.Objects)
                    {
                        ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(resultItem.ToString());
                        producto.Productos.Add(resultItemList);

                    }
                }
                else
                {
                    ViewBag.Mensaje = "Ocurrio un error al obtener la informacion";
                    return PartialView("Modal");
                }
            }
            return View(producto);
        }

        [HttpGet]
        public ActionResult Form(int? IdProducto)
        {

            ML.Producto producto = new ML.Producto();
            ML.Result resultProducto = new ML.Result();
            producto.MateriaPrima = new ML.MateriaPrima();
            ML.Result resultmaterias = BL.MateriaPrima.GetAll(); 

            if (IdProducto == null )
            {
                producto.MateriaPrima.MateriasPrima = resultmaterias.Objects;
                return View(producto);
            }
            else
            {
                using (var client = new HttpClient())
                {
                    string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                    client.BaseAddress = new Uri(urlApi);
                    var responseTask = client.GetAsync("api/producto/" + IdProducto);
                    responseTask.Wait();

                    var resultTask = responseTask.Result;

                    if (resultTask.IsSuccessStatusCode)
                    {
                        var readTask = resultTask.Content.ReadAsAsync<ML.Result>();
                        readTask.Wait();

                            ML.Producto resultItemList = Newtonsoft.Json.JsonConvert.DeserializeObject<ML.Producto>(readTask.Result.Object.ToString());
                            resultProducto.Object=resultItemList;
                        
                    }
                    producto = (ML.Producto)resultProducto.Object;
                    producto.MateriaPrima.MateriasPrima = resultmaterias.Objects;
                }
                return View(producto);


            }

        }
        [HttpPost]
        public ActionResult Form(ML.Producto producto)
        {
            if (producto.IdProducto == 0)
            {
                using (var client = new HttpClient())
                {
                    string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                    client.BaseAddress = new Uri(urlApi);
                    var postTask = client.PostAsJsonAsync<ML.Producto>("api/producto/", producto);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se agrego correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error" + result.RequestMessage;
                    }

                }
            }
            else
            {
                using (var client = new HttpClient())
                {
                    string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                    client.BaseAddress = new Uri(urlApi);
                    var postTask = client.PutAsJsonAsync<ML.Producto>("api/producto/", producto);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        ViewBag.Message = "Se actualizo correctamente";
                    }
                    else
                    {
                        ViewBag.Message = "Ocurrio un error" + result.RequestMessage;
                    }

                }

            }
            return View("Modal");

        }
        [HttpGet]
        public ActionResult Delete(int IdProducto)
        {
            ML.Result resultProducto = new ML.Result();

            using (var client = new HttpClient())
            {
                string urlApi = ConfigurationManager.AppSettings["WebApi"].ToString();
                client.BaseAddress = new Uri(urlApi);
                var responseTask = client.DeleteAsync("api/producto/Delete/" + IdProducto);
                responseTask.Wait();

                var resultTask = responseTask.Result;

                if (resultTask.IsSuccessStatusCode)
                {
                    var readTask = resultTask.Content.ReadAsAsync<ML.Result>();
                    readTask.Wait();  

                }

            }
            return View("Modal");
        }



    }
}