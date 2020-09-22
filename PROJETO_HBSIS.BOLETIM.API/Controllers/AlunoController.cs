using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;


namespace PROJETO_HBSIS.BOLETIM.API.Controllers
{
    [ApiController]
    [Route("Alunos")]
    public class AlunoController : ControllerBase
    {
        private readonly IBoletimNegocio rn;
        public AlunoController(IBoletimNegocio regraNegocio)
        {
            rn = regraNegocio;
        }

        [HttpGet]
        public ActionResult Get()
        {
            var result = rn.ListarAlunos();
            return Ok(result);
        }

        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Aluno aluno)
        {
            var result = rn.CadastrarAluno(aluno);
            return Ok(result);
        }

        [HttpPost]
        [Route("MatricularAlunoEmCurso")]
        public ActionResult Matricular(Aluno aluno)
        {
            var result = rn.MatricularAluno(aluno.Id, aluno.IdCurso);
            return Ok(result);
        }

        [HttpPost]
        [Route("GradeMateriaCurso")]
        public ActionResult ListarMateriasdoCurso(int idAluno)
        {
            var result =  rn.ListarMateriasdoCurso(idAluno);
            return Ok(result);
        }

        [HttpPost]
        [Route("MatricularAlunoEmMateria")]
        public ActionResult MatricularAlunoEmMateria((int,int) itens)
        {
            var result = rn.MatricularAlunoEmMateria(itens.Item1, itens.Item2);
            return Ok(result);
        }


        [HttpPost]
        [Route("AtribuirNotaAluno")]
        public ActionResult AtribuirNotaAluno((int,int,double) dados)
        {
            var idAluno = dados.Item1;
            var idMateria = dados.Item2;
            var nota = dados.Item3;
            var result = rn.AtribuirNotaEmMateria(idAluno, idMateria, nota);
            return Ok(result);
        }

        [HttpPost]
        [Route("ListarNotaAluno")]
        public ActionResult ListarNotaAluno(Usuario user)
        {
            var result = rn.ListarNotaAluno(user.Id);
            return Ok(result);
        }
    }
}
