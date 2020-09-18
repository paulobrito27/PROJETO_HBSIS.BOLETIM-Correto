
using System;

namespace PROJETO_HBSIS.BOLETIM.MODELS
{
    public class Aluno : Usuario
    {
        public int IdCurso { get; set; }
        public virtual Curso Curso { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
