using System.Collections.Generic;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZabudApi.Models;

namespace ZabudApi.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        ProductsDataAccesLayer data = new ProductsDataAccesLayer();


        [HttpGet]
        public IEnumerable<Products> getallProducts()
        {
            return data.getAllProducts();
        }


         [DisableCors]
        [HttpPost]
        public ActionResult create([FromBody] Products products)
        {
            int dato;
            string mensaje;
            dato = data.AddProducts(products);
            if (dato == 1)
            {
                mensaje = "Se agrego con exito el producto ";
                return Ok(mensaje);
            }
            mensaje = "Ocurrio un error";
            return BadRequest(mensaje);

        }

         [DisableCors]
        [HttpPut]
        public ActionResult update([FromBody] Products products)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            int success = data.UpdateProduct(products);
            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }
        [DisableCors]
        [HttpGet("{id}")]
        public ActionResult getByID(int id)
        {
            Products products = data.getProductById(id);
            if(products !=null){
                return Ok(products);
            }else{
                return NotFound();
            }
                
        }
    }
}