using Microsoft.AspNetCore.Mvc;
using PROJETO_HBSIS.BOLETIM.API.Results;
using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Validation;
using System;
using System.Linq;
using System.Net;

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
            var lista = db.Listar();
            return Ok(lista);
        }

      //      var result = new PadraoResult<Materia>();
      //      try
      //      {
      //          using (_banco)
      //          {
      //              result.Error = false;
      //              result.Status = HttpStatusCode.OK;
      //              result.Data = _banco.Materias.ToList();
      //              return Ok(result);
      //          }
      //      }
      //      catch (Exception e)
      //      {
      //          result.Error = true;
      //          result.Message[0] = e.Message;
      //          return BadRequest(result);
      //      }
      //  }

  //    [HttpPost]
  //    [Route("Cadastrar")]
  //    public ActionResult Cadastrar(Materia materia)
  //    {
  //        var validator = new MateriaValidator();
  //        var valida = validator.Valida(materia);
  //        var result = new PadraoResult<Materia>();
  //
  //        if (!valida.IsValid)
  //        {
  //            result.Error = true;
  //            result.Message = valida.Erros;
  //            result.Status = HttpStatusCode.BadRequest;
  //            return Ok(result);
  //        }
  //
  //        foreach(var item in _banco.Materias)
  //        {
  //            if (item.Nome == materia.Nome)
  //            {
  //                result.Error = true;
  //                result.Message.Add($"O nome {materia.Nome} já esta cadastrado");
  //                result.Status = HttpStatusCode.BadRequest;
  //                return Ok(result);
  //            }   
  //        }
  //
  //        try
  //        {
  //            using (_banco)
  //            {
  //                _banco.Add(materia);
  //                _banco.SaveChanges();
  //                result.Error = false;
  //                result.Status = HttpStatusCode.OK;
  //                result.Data = _banco.Materias.ToList();
  //                return Ok(result);
  //            }
  //        }
  //        catch (Exception e)
  //        {
  //            result.Error = true;
  //            result.Message[0] = e.Message;
  //            return BadRequest(result);
  //        }
  //    }
    }
}
