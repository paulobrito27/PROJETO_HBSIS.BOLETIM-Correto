using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PROJETO_HBSIS.BOLETIM.MODELS
{
    public class Aluno : Usuario
    {
        public int Id { get; set; }
        public int IdCurso { get; set; }
        public virtual Curso Curso { get; set; }
    }
}
