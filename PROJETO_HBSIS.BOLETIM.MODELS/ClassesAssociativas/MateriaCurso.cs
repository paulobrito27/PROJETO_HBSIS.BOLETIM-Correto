
namespace PROJETO_HBSIS.BOLETIM.MODELS.ClassesAssociativas
{
    public class MateriaCurso
    {
        public int MateriaId { get; set; }
        public  Materia Materia { get; set; }
        public int CursoId { get; set; }
        public Curso Curso { get; set; }

    }
}
