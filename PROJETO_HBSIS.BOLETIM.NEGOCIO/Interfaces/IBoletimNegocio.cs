using PROJETO_HBSIS.BOLETIM.MODELS;
using System.Collections.Generic;


namespace PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces
{
    public interface IBoletimNegocio
    {
        List<Materia> Listar();
        void Gravar(Materia materia);

    }
}
