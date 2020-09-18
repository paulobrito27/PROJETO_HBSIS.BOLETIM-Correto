using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Results;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Validation;
using System;
using System.Linq;
using System.Net;

namespace PROJETO_HBSIS.BOLETIM.NEGOCIO
{
    public class BoletimNegocio : IBoletimNegocio
    {

        private readonly BancoContext db;

        public BoletimNegocio(BancoContext banco)
        {
            db = banco;
        }


        public PadraoResult<Materia> CadastrarMateria(Materia materia)
        {
            var validator = new MateriaValidator();
            var valida = validator.Valida(materia);
            var result = new PadraoResult<Materia>();
            if (!valida.IsValid)
            {
                result.Error = true;
                result.Message = valida.Erros;
                result.Status = HttpStatusCode.BadRequest;
                return result;
            }

            try
            {
                using (db)
                {
                    foreach (var item in db.Materias)
                    {
                        if (item.Nome == materia.Nome)
                        {
                            result.Error = true;
                            result.Message.Add($"O nome {materia.Nome} já esta cadastrado");
                            result.Status = HttpStatusCode.BadRequest;
                            return result;
                        }
                    }
                    db.Add(materia);
                    db.SaveChanges();
                    result.Error = false;
                    result.Status = HttpStatusCode.OK;
                    result.Data = db.Materias.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message.Add(e.Message);
                result.Status = HttpStatusCode.BadRequest;
                return result;
            }
        }

        public PadraoResult<Materia> DeleteMateria(int id)
        {
            var result = new PadraoResult<Materia>();
            try
            {
                using (db)
                {
                    var materia = db.Materias.Where(q => q.Id == id).FirstOrDefault();
                    db.Materias.Remove(materia);
                    db.SaveChanges();
                    result.Error = false;
                    result.Status = HttpStatusCode.OK;
                    result.Data = db.Materias.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message.Add(e.Message);
                result.Status = HttpStatusCode.BadRequest;
                return result;
            }

        }

        public PadraoResult<Materia> ListarMaterias()
        {
            var result = new PadraoResult<Materia>();
            try
            {
                using (db)
                {
                    result.Error = false;
                    result.Status = HttpStatusCode.OK;
                    result.Data = db.Materias.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message.Add(e.Message);
                return result;
            }
        }

        public PadraoResult<Materia> UpdateMateria(int id, Materia matAtualizada)
        {
            var validator = new MateriaValidator();
            var valida = validator.Valida(matAtualizada);
            var result = new PadraoResult<Materia>();
            if (!valida.IsValid)
            {
                result.Error = true;
                result.Message = valida.Erros;
                result.Status = HttpStatusCode.BadRequest;
                return result;
            }

            try
            {
                using (db)
                {
                    var materia = db.Materias.Where(q => q.Id == id).FirstOrDefault();
                    if (materia == null)
                    {
                        result.Error = true;
                        result.Message.Add("Id de materia não existe no nosso banco!");
                        result.Status = HttpStatusCode.BadRequest;
                        return result;
                    }

                    materia.Nome = matAtualizada.Nome;
                    materia.Situacao = matAtualizada.Situacao;
                    materia.Descricao = matAtualizada.Descricao ;
                    materia.DataCadastro = matAtualizada.DataCadastro ;

                    db.SaveChanges();
                    result.Error = false;
                    result.Status = HttpStatusCode.OK;
                    result.Data = db.Materias.ToList();
                    return result;
                }
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message.Add(e.Message);
                result.Status = HttpStatusCode.BadRequest;
                return result;
            }
        }
    }
}
