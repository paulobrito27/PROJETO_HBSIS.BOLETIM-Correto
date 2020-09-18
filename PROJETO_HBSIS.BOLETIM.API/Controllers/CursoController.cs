using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJETO_HBSIS.BOLETIM.API.Results;
using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Validation;
using System;
using System.Linq;
using System.Net;
using System.Security.Cryptography;

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
            var result = rn.ListarCursos2();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddMateria")]
        public ActionResult AdicionarMaterias(string nome_curso, string nome_materia)
        {
            var result = rn.Add_Mat_em_Curso(nome_curso, nome_materia);
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
