using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;
using PROJETO_HBSIS.BOLETIM.MODELS.Enum;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;

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

        [JsonIgnore]
        [IgnoreDataMember]
        public  virtual ICollection<MateriaCurso> Cursos { get; set; } = new HashSet<MateriaCurso>();
        public  virtual ICollection<ProfessorMateria> Professores { get; set; } = new HashSet<ProfessorMateria>();
    }
}
