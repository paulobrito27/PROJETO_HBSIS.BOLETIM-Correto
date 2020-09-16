using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;
using System;
using System.Collections.Generic;
using System.Text;

namespace PROJETO_HBSIS.BOLETIM.MODELS
{
    public class Professor : Usuario
    {

        public ICollection<ProfessorMateria> ProfessorMaterias { get; set; } = new HashSet<ProfessorMateria>();

    }
}
