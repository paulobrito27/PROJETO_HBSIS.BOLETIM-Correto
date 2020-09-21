using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.MODELS;
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
        public ActionResult Logar(Usuario usuario)
        {

            var login = usuario.Login;
            var password = usuario.Password;
            var result = rn.LogarUsuario(login,password);
            return Ok(result);
        }

        

    }
}
