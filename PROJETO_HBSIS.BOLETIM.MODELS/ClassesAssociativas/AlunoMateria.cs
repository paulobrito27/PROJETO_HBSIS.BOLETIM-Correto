using System.Runtime.Serialization;
using System.Text.Json.Serialization;

namespace PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas
{
    public class AlunoMateria
    {
        [JsonIgnore]
        [IgnoreDataMember]
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public int AlunoId { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public Aluno Aluno  { get; set; }
        
        public double Nota { get; set; }
    }
}
