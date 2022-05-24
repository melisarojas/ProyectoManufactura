using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SL.Controllers
{
    public class ProductoController : ApiController
    {
        // GET: api/Producto
        [Route("api/producto/GetAll/{IdMateriaPrima}")]
        [HttpGet]
        public IHttpActionResult GetAll(int IdMateriaPrima)
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.GetAll(IdMateriaPrima);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }



        // GET: api/Producto/5
        [Route("api/producto/{IdProducto}")]
        [HttpGet]
        public IHttpActionResult GetById(int IdProducto)  
        {
            ML.Result result = BL.Producto.GetById(IdProducto);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.NotFound, result);
            }

        }

        [Route("api/producto/")]
        [HttpPost]
        public IHttpActionResult Add(ML.Producto producto)
        {
            ML.Result result = BL.Producto.Add(producto);
            if (result.Correct)
            {
                return Content(HttpStatusCode.Created, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // PUT: api/Producto/5
        [Route("api/producto/")]
        [HttpPut]
        public IHttpActionResult Update(ML.Producto producto) 
        {
            ML.Result result = BL.Producto.Update(producto);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }

        // DELETE: api/Producto/5
        [Route("api/producto/Delete/{IdProducto}")]
        [HttpDelete]
        public IHttpActionResult Delete(int IdProducto)  //POSTMAN OK
        {
            ML.Producto producto = new ML.Producto();
            ML.Result result = BL.Producto.Delete(IdProducto);

            if (result.Correct)
            {
                return Content(HttpStatusCode.OK, result);
            }
            else
            {
                return Content(HttpStatusCode.BadRequest, result);
            }
        }
    }
}
