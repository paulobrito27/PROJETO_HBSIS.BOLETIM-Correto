using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;
using PROJETO_HBSIS.BOLETIM.MODELS.Enum;
using System;
using System.Collections.Generic;

namespace PROJETO_HBSIS.BOLETIM.MODELS
{
    public class Materia
    {
        public int Id { get; set;}
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public DateTime DataCadastro { get; set; }
        public StatusMateriaEnum Situacao { get; set; }
        public double Nota { get; set; }
        public ICollection<MateriaCurso> MateriaCursos{ get; set; } = new HashSet<MateriaCurso>();
        public ICollection<ProfessorMateria> ProfessorMaterias { get; set; } = new HashSet<ProfessorMateria>();
    }
}
