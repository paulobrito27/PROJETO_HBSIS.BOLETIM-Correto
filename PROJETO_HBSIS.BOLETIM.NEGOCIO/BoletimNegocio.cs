using PROJETO_HBSIS.BOLETIM.CONTEXT;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.NEGOCIO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJETO_HBSIS.BOLETIM.NEGOCIO
{
    public class BoletimNegocio : IBoletimNegocio
    {

        private readonly BancoContext BD;

        public BoletimNegocio(BancoContext banco)
        {
            BD = banco;
        }

        public void Gravar(Materia objeto)
        {
            throw new NotImplementedException();
        }

        public List<Materia> Listar()
        {
            try
            {
                using (BD)
                {
                    return BD.Materias.ToList();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
