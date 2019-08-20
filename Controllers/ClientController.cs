using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ZabudApi.Models;

namespace ZabudApi.Controllers
{
    [EnableCors("AllowAnyOrigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        ClientDataAccesLayer data = new ClientDataAccesLayer();

        [HttpGet]
        public IEnumerable<Client> getAll()
        {
           return  data.getAll();
        }

        [HttpPost]
        public IActionResult create([FromBody] Client client)
        {
            int dato;
            string mensaje  = "";
            dato = data.AddClient(client);
            if(dato == 1 ){
                mensaje = "Se agrego con exito el usuario ";
                string salida = JsonConvert.SerializeObject(mensaje);
                return Ok(salida);
            }
            mensaje = "Ocurrio un error";
            return BadRequest(mensaje);
                
        }

        [HttpPut]
        public ActionResult update([FromBody] Client client)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest();
            }

            int success = data.UpdateClient(client);
            if (success == 1)
            {
                return Ok();
            }

            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult getByID(int id)
        {
            Client client = data.GetClientsAll(id);
            if(client !=null){
                return Ok(client);
            }else{
                return NotFound();
            }
                
        }

        
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            
            int dato = data.DeleteClient(id);
            if(dato == 1 ){
                return Ok();
            }

            
            return NoContent();
             
        }
    }
}