﻿using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;
using System.Linq;

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
        [Route("Matricular")]
        public ActionResult Matricular(int idAluno, int idCurso)
        {
            var result = rn.MatricularAluno(idAluno, idCurso);
            return Ok(result);
        }

        

    }
}
