using System.Collections.Generic;

namespace PROJETO_HBSIS.BOLETIM.VALITATOR.Result
{
    public class ValidatorResult 
    {
        public bool IsValid { get; set; }
        public List<string> Erros { get; set; } 

        public ValidatorResult()
        {
            Erros = new List<string>();
            IsValid = true;
        }
    }
}
