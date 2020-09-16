using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Result;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PROJETO_HBSIS.BOLETIM.VALITATOR.Validation
{
    public class CursoValidator
    {

        public ValidatorResult validador = new ValidatorResult();

        public ValidatorResult Valida(Curso _curso)
        {
            //Valida Nome
            if (_curso.Nome == null)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome não pode estar vazio!");
                return validador;
            }
            if (_curso.Nome.Length < 3)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome tem que conter mais que 3 letras!");
            }
            if (_curso.Nome.Length > 40)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome não pode ter mais que 40 caracteres!");
            }
            if (ValidaSoLetras(_curso))
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome só poder conter letras!");
            }

            if (_curso.Situacao != MODELS.Enum.StatusCursoEnum.ATIVO && _curso.Situacao != MODELS.Enum.StatusCursoEnum.CANCELADO && _curso.Situacao != MODELS.Enum.StatusCursoEnum.PREVISTO)
            {
                validador.IsValid = false;
                validador.Erros.Add("Curso deve constar como 'Ativa' ou 'Cancelado ou 'Previsto'!");
            }


            return validador;
        }

        private bool ValidaSoLetras(Curso curso)
        {
            foreach (var letra in curso.Nome)
            {
                if (!char.IsWhiteSpace(letra) && !char.IsLetter(letra))
                {
                    return true;
                }
            }
            return false;
        }

           
      
    }
}
