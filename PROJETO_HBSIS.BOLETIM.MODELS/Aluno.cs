
using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;
using System;
using System.Collections.Generic;

namespace PROJETO_HBSIS.BOLETIM.MODELS
{
    public class Aluno : Usuario
    {
        public int IdCurso { get; set; }
        public  Curso Curso { get; set; }
        public DateTime DataNascimento { get; set; }

       
        public virtual ICollection<AlunoMateria> AlunoMaterias { get; set; } = new HashSet<AlunoMateria>();
    }
}
