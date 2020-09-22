using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;


namespace PROJETO_HBSIS.BOLETIM.API.Controllers
{
    [ApiController]
    [Route("Cursos")]
    public class CursoController : ControllerBase
    {
        private readonly IBoletimNegocio rn;
        public CursoController(IBoletimNegocio regraNegocio)
        {
            rn = regraNegocio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = rn.ListarCursos();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddMateria")]
        public ActionResult AdicionarMaterias((string,string) dados)
        {
            var result = rn.Add_Mat_em_Curso(dados.Item1, dados.Item2);
            return Ok(result);
        }

        [HttpPost]
       [Route("Cadastrar")]
       public ActionResult Cadastrar(Curso curso)
       {
           var result= rn.CadastrarCurso(curso);
            return Ok(result);
       }
    }

}
