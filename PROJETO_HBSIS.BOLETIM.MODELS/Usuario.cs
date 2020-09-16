using PROJETO_HBSIS.BOLETIM;
using PROJETO_HBSIS.BOLETIM.MODELS.Enum;

namespace PROJETO_HBSIS.BOLETIM.MODELS
{
    public class Usuario : Pessoa
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string  Password { get; set; }

        public TipoUsuarioEnum TipoUsuario { get; set; }
    }
}
