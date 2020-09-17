using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;


namespace PROJETO_HBSIS.BOLETIM.API.Controllers
{
    [ApiController]
    [Route("Materias")]
    public class MateriaController : ControllerBase
    {
        private readonly IBoletimNegocio db;
        public MateriaController(IBoletimNegocio banco)
        {
            db = banco;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = db.ListarMaterias();
            return Ok(result);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Materia materia)
        {
            var result = db.CadastrarMateria(materia);
            return Ok(result);
        }
    }
}
