using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;


namespace PROJETO_HBSIS.BOLETIM.API.Controllers
{
    [ApiController]
    [Route("Materias")]
    public class MateriaController : ControllerBase
    {
        private readonly IBoletimNegocio rn;
        public MateriaController(IBoletimNegocio regraNegocio)
        {
            rn = regraNegocio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = rn.ListarMaterias();
            return Ok(result);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Materia materia)
        {
            var result = rn.CadastrarMateria(materia);
            return Ok(result);
        }
        [HttpPost]
        [Route("Deletar")]
        public ActionResult Deletar(Materia materia)
        {
            int id = materia.Id;
            var result = rn.DeleteMateria(id);
            return Ok(result);
        }

        [HttpPost]
        [Route("Alterar")]
        public ActionResult Alterar(Materia materia)
        {
            var result = rn.UpdateMateria(materia.Id, materia);
            return Ok(result);
        }
    }
}
