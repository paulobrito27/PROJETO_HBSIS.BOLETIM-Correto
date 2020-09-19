using Newtonsoft.Json;
using PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas;
using PROJETO_HBSIS.BOLETIM.MODELS.Enum;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace PROJETO_HBSIS.BOLETIM.MODELS
{
    public class Curso
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public StatusCursoEnum Situacao { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public  ICollection<Aluno> Alunos { get; set; } = new HashSet<Aluno>();
        public virtual ICollection<MateriaCurso> Materias { get; set; } = new HashSet<MateriaCurso>();
    }
}
