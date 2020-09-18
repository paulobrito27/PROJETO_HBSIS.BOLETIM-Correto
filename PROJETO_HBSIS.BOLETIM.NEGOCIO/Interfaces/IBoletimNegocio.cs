using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Results;



namespace PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces
{
    public interface IBoletimNegocio
    {
        PadraoResult<Materia> ListarMaterias();
        PadraoResult<Materia> CadastrarMateria(Materia materia);
        PadraoResult<Materia> UpdateMateria(int id, Materia matAtualizada);
        PadraoResult<Materia> DeleteMateria(int id);
        void CriaAdministradorDefault();
        PadraoResult<Usuario> LogarUsuario(string login, string password);

    }
}
