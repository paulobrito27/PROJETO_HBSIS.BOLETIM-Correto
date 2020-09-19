namespace PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas
{
    public class AlunoMateria
    {
        public int MateriaId { get; set; }
        public Materia Materia { get; set; }
        public int AlunoId { get; set; }
        public Aluno Aluno  { get; set; }
        public double Nota { get; set; }
    }
}
