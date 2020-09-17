using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Results;
using System.Collections.Generic;


namespace PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces
{
    public interface IBoletimNegocio
    {
        PadraoResult<Materia> ListarMaterias();
        PadraoResult<Materia> CadastrarMateria(Materia materia);

    }
}
