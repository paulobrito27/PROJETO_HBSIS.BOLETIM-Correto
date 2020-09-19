using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Results;


namespace PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces
{
    public interface IBoletimNegocio
    {
  
        //materiaController-------------------------
        PadraoResult<Materia> ListarMaterias();
        PadraoResult<Materia> CadastrarMateria(Materia materia);
        PadraoResult<Materia> UpdateMateria(int id, Materia matAtualizada);
        PadraoResult<Materia> DeleteMateria(int id);



        //LoginController----------------------------
        void CriaAdministradorDefault();
        PadraoResult<Usuario> LogarUsuario(string login, string password);



        //CursoController-----------------------------

        PadraoResult<Curso> ListarCursos();
        PadraoResult<Curso> CadastrarCurso(Curso curso);
        PadraoResult<Curso> Add_Mat_em_Curso(string nomeCurso, string nomeMateria);


        //AlunoController-----------------------------
        PadraoResult<Aluno> ListarAlunos();
        PadraoResult<Aluno> CadastrarAluno(Aluno aluno);
        PadraoResult<Aluno> MatricularAluno(int idAluno, int idCurso);
        object ListarMateriasdoCurso(int idAluno);
        PadraoResult<Aluno> MatricularAlunoEmMateria(int idAluno, int idMateria);
    }
}
