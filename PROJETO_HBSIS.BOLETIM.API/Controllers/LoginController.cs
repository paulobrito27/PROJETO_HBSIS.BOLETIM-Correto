using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;


namespace PROJETO_HBSIS.BOLETIM.API.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        private readonly IBoletimNegocio rn;
        public LoginController(IBoletimNegocio regraNegocio)
        {
            rn = regraNegocio;
        }


        [HttpPost]
        public ActionResult Logar(string login, string password)
        {
            var result = rn.LogarUsuario(login,password);
            return Ok(result);
        }

    }
}
