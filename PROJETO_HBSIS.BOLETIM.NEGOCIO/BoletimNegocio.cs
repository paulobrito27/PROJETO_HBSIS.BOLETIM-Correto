using Microsoft.EntityFrameworkCore;
using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Results;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Validation;
using System;
using System.Collections.Generic;
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

        public PadraoResult<Curso> Add_Mat_em_Curso(string nomeCurso, string nomeMateria)
        {
            var result = new PadraoResult<Curso>();
            using (db)
            {
                try
                {
                    var cursos = db.Cursos.ToList();
                    var materias = db.Materias.ToList();
                    var curso = cursos.Where(q => q.Nome.ToLower() == nomeCurso.ToLower()).Select(q => q).FirstOrDefault();
                    var materia = materias.Where(q => q.Nome.ToLower() == nomeMateria.ToLower()).Select(q => q).FirstOrDefault();

                    if (curso == null)
                    {
                        result.Error = true;
                        result.Message.Add("Curso não encontrado");
                        result.Status = HttpStatusCode.BadRequest;
                        return result;
                    }
                    if (materia == null)
                    {
                        result.Error = true;
                        result.Message.Add("Materia não encontrada");
                        result.Status = HttpStatusCode.BadRequest;
                        return result;
                    }
                    if (materia.Situacao == MODELS.Enum.StatusMateriaEnum.INATIVO)
                    {
                        result.Error = true;
                        result.Message.Add("Materia com Status 'INATIVO', não pode ser adicionada ao curso!");
                        result.Status = HttpStatusCode.BadRequest;
                        return result;
                    }

                    curso.Materias.Add(new MateriaCurso()
                    {
                        Materia = materia,
                        Curso = curso
                    });
                    db.SaveChanges();


                    result.Error = false;
                    result.Message.Add("OK");
                    result.Status = HttpStatusCode.OK;
                    result.Data = db.Cursos.Include(q => q.Materias).ToList();
                    return result;

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

        public PadraoResult<Curso> CadastrarCurso(Curso curso)
        {
            var validator = new CursoValidator();
            var valida = validator.Valida(curso);
            var result = new PadraoResult<Curso>();

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
                    foreach (var item in db.Cursos)
                    {
                        if (item.Nome == curso.Nome)
                        {
                            result.Error = true;
                            result.Message.Add($"O nome {curso.Nome} já esta cadastrado");
                            result.Status = HttpStatusCode.BadRequest;
                            return result;
                        }
                    }

                    db.Cursos.Add(curso);
                    db.SaveChanges();
                    result.Error = false;
                    result.Status = HttpStatusCode.OK;
                    result.Data = db.Cursos.ToList();
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

        public void CriaAdministradorDefault()
        {
            using (db)
            {
                if (db.Administradors.ToList().Count < 1)
                {
                    Administrador adm = new Administrador()
                    {
                        Nome = "Admin",
                        Sobrenome = "Adimin",
                        Login = "admin",
                        Password = "admin",
                        Cpf = "000.000.000-00",
                        TipoUsuario = MODELS.Enum.TipoUsuarioEnum.ADMINISTRADOR
                    };
                    db.Administradors.Add(adm);
                    db.SaveChanges();
                }
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

        public PadraoResult<Curso> ListarCursos()
        {
            var result = new PadraoResult<Curso>();
            try
           {
                using (db)
                {
                    result.Error = false;
                    result.Message.Add("OK");
                    result.Status = HttpStatusCode.OK;
                    result.Data = db.Cursos.ToList();
                    return result;
                    //return db.Cursos.Select(s => new { CursoName = s.Nome, ListaMateria = s.Materias.Select(r => r.Materia.Nome).ToList() }).ToList();
                }
            }
            catch (Exception e)
            {
                result.Error = true;
                result.Message.Add(e.Message);
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

        public PadraoResult<Usuario> LogarUsuario(string login, string password)
        {
            var result = new PadraoResult<Usuario>();
            Usuario usuario;

            using (db)
            {
                usuario = db.Administradors.Where(q => q.Login == login && q.Password == password).FirstOrDefault();
                if (usuario == null)
                {
                    usuario = db.Professors.Where(q => q.Login == login && q.Password == password).FirstOrDefault();
                }
                if (usuario == null)
                {
                    usuario = db.Alunos.Where(q => q.Login == login && q.Password == password).FirstOrDefault();
                }
                if (usuario == null)
                {
                    result.Error = false;
                    result.Status = HttpStatusCode.NotFound;
                    result.Message.Add("Usuario não cadastrado");
                    return result;
                }

                result.Error = true;
                result.Status = HttpStatusCode.OK;
                result.Message.Add("ok");

                result.Data.Add(usuario);

            }
            return result;
        }

        public PadraoResult<Curso> Remove_Mat_em_Curso(string nomeCurso, string nomeMateria)
        {
            throw new NotImplementedException();
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
                    materia.Descricao = matAtualizada.Descricao;
                    materia.DataCadastro = matAtualizada.DataCadastro;

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
