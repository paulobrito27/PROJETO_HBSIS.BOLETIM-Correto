using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.MODELS;

namespace PROJETO_HBSIS.BOLETIM.API.Controllers
{
    [ApiController]
    [Route("Home")]
    public class HomeController : ControllerBase
    {

        public HomeController()
        {

        }

        [HttpGet]
        public ActionResult Get()
        {
            return Ok("Conectado");
        }
    }
}
