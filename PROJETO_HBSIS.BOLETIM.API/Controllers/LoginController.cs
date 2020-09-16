using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.API.Results;
using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using System.Net;

namespace PROJETO_HBSIS.BOLETIM.API.Controllers
{
    [ApiController]
    [Route("Login")]
    public class LoginController : ControllerBase
    {
        private readonly BancoContext _banco;
        public LoginController(BancoContext db)
        {
            _banco = db;
        }


        [HttpPost]
        public ActionResult Logar(Usuario usuario)
        {
            var result = new PadraoResult<Usuario>();

            using (_banco)
            {
                //pesquisa dentro de administradores
                foreach (var user in _banco.Administradors)
                {
                    if (user.Login == usuario.Login && user.Password == usuario.Password)
                    {
                        result.Data.Add(user);
                        result.Error = false;
                        result.Status = HttpStatusCode.OK;
                        return Ok(result);
                    }
                }
                //pesquisa dentro de Professores
                foreach (var user in _banco.Professors)
                {
                    if (user.Login == usuario.Login && user.Password == usuario.Password)
                    {
                        result.Data.Add(user);
                        result.Error = false;
                        result.Status = HttpStatusCode.OK;
                        return Ok(result);
                    }
                }
                //pesquisa dentro de Alunos
                foreach (var user in _banco.Alunos)
                {
                    if (user.Login == usuario.Login && user.Password == usuario.Password)
                    {
                        result.Data.Add(user);
                        result.Error = false;
                        result.Status = HttpStatusCode.OK;
                        return Ok(result);
                    }
                }

                
                result.Error = true;
                result.Status = HttpStatusCode.NotFound;
                result.Message.Add ("Usuario não cadastrado");
                return Ok(result);
            }
        }

    }
}
