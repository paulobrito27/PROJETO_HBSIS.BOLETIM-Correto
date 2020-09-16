using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using System;
using System.Linq;

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
            using (_banco)
            {
                //pesquisa dentro de administradores
                foreach (var user in _banco.Administradors)
                {
                    if (user.Login == usuario.Login && user.Password == usuario.Password)
                    {
                        return Ok(user);
                    }
                }
                //pesquisa dentro de Professores
                foreach (var user in _banco.Professors)
                {
                    if (user.Login == usuario.Login && user.Password == usuario.Password)
                    {
                        return Ok(user);
                    }
                }
                //pesquisa dentro de Alunos
                foreach (var user in _banco.Alunos)
                {
                    if (user.Login == usuario.Login && user.Password == usuario.Password)
                    {
                        return Ok(user);
                    }
                }

                return BadRequest("Usuario não cadastrado");
            }
        }

    }
}
