using Microsoft.AspNetCore.Mvc;
using ApiSite.Services;
using ApiSite.Models;
using Microsoft.AspNetCore.Http;

namespace ApiSite.Controllers
{
    [Route("api/[controller]")]    
    public class ValuesController : Controller
    {
        // GET api/values
        [HttpGet]
        [ProducesResponseType(typeof(DadosPagina), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Get()
        {
            FilaServices fila = new FilaServices("FilaSite");
            //var resultado = fila.RetrieveSingleMessage();
            var dadosPagina = fila.ReturnMessage();

            return Ok(dadosPagina);

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        [ProducesResponseType(typeof(DadosPagina), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult Post([FromBody] DadosPagina dadosPagina)
        {
            FilaServices fila = new FilaServices("FilaSite");
            var resultado = fila.WriteMessageOnQueue(dadosPagina);
            

            if (resultado)
            {
                return Ok(dadosPagina);
            }
            else
            {
                return BadRequest();
            }                                
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
