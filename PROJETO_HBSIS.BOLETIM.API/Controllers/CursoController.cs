using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.API.Results;
using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using System;
using System.Linq;
using System.Net;

namespace PROJETO_HBSIS.BOLETIM.API.Controllers
{
    [ApiController]
    [Route("Cursos")]
    public class CursoController : ControllerBase
    {
        private readonly BancoContext _banco;
        public CursoController(BancoContext db)
        {
            _banco = db;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = new PadraoResult<Curso>();
            try
            {
                using (_banco)
                {
                    result.Error = false;
                    result.Status = HttpStatusCode.OK;
                    result.Data = _banco.Cursos.ToList();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message[0] = e.Message;
                return BadRequest(result);
            }

        }

        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Curso curso)
        {

            return Ok();
        }
    }
}
