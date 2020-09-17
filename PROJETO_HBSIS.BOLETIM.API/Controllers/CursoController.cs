﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PROJETO_HBSIS.BOLETIM.API.Results;
using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Validation;
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
                    result.Data = _banco.Cursos.Include(q=>q.Materias).ToList();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message.Add(e.Message);
                return BadRequest(result);
            }
        }

        [HttpPost]
        [Route("AddMateria")]
        public ActionResult AdicionarMaterias( string nome_curso, string nome_materia)
        {
            var result = new PadraoResult<Curso>();


            var cursos = _banco.Cursos.ToList();
            var materias = _banco.Materias.ToList();

            var curso = cursos.Where(q => q.Nome.ToLower() == nome_curso.ToLower()).Select(q => q).FirstOrDefault();
            var materia = materias.Where(q => q.Nome.ToLower() == nome_materia.ToLower()).Select(q => q).FirstOrDefault();
            curso.Materias.Add(new MateriaCurso()
                {
                    Materia = materia,
                    Curso = curso
                });
            
            _banco.SaveChanges();

            result.Data = cursos;
            return Ok(result);
        }





        [HttpPost]
        [Route("Cadastrar")]
        public ActionResult Cadastrar(Curso curso)
        {
            var validator = new CursoValidator();
            var valida = validator.Valida(curso);
            var result = new PadraoResult<Curso>();

            if (!valida.IsValid)
            {
                result.Error = true;
                result.Message = valida.Erros;
                result.Status = HttpStatusCode.BadRequest;
                return Ok(result);
            }

            foreach (var item in _banco.Cursos)
            {
                if (item.Nome == curso.Nome)
                {
                    result.Error = true;
                    result.Message.Add($"O nome {curso.Nome} já esta cadastrado");
                    result.Status = HttpStatusCode.BadRequest;
                    return Ok(result);
                }
            }

            try
            {
                using (_banco)
                {
                    _banco.Cursos.Add(curso);
                    _banco.SaveChanges();
                    result.Error = false;
                    result.Status = HttpStatusCode.OK;
                    result.Data = _banco.Cursos.ToList();
                    return Ok(result);
                }
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message.Add(e.Message);
                return BadRequest(result);
            }

        }







    }


}
