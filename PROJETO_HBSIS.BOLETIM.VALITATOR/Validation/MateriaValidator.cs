using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Result;
using System;

namespace PROJETO_HBSIS.BOLETIM.VALITATOR.Validation
{
    public class MateriaValidator
    {
        
        public  ValidatorResult validador = new ValidatorResult();

        public  ValidatorResult Valida(Materia _materia)
        {
            //Valida Nome
            if(_materia.Nome == null)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome não pode estar vazio!");
                return validador;
            }
            if (_materia.Nome.Length < 3)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome tem que conter mais que 3 letras!");
            }
            if (_materia.Nome.Length > 40)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome não pode ter mais que 40 caracteres!");
            }


            //Valida Descrição
            if (_materia.Descricao == null)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo descrição não pode estar vazio!");
                return validador;
            }
            if (_materia.Descricao.Length < 1)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo descrição não pode estar vazio!");
                return validador;
            }
            if (ValidaSoLetras(_materia))
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo descrição só poder conter letras!");
            }
            if (_materia.Descricao.Length > 80)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome não pode ter mais que 40 caracteres!");
            }


            //Valida data
            if (_materia.DataCadastro == DateTime.Parse("01-01-0001"))
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo data não pode estar vazio!");
                return validador;
            }
            if (_materia.DataCadastro > DateTime.Now)
            {
                validador.IsValid = false;
                validador.Erros.Add($"Data informada não pode ser superior a data atual {DateTime.Now}!");
            }


            if(_materia.Situacao != MODELS.Enum.StatusMateriaEnum.ATIVO && _materia.Situacao != MODELS.Enum.StatusMateriaEnum.INATIVO)
            {
                validador.IsValid = false;
                validador.Erros.Add("Matéria deve constar como 'Ativa' ou 'Inativa'!");
            }

            return validador;
        }

        private  bool ValidaSoLetras(Materia _materia)
        {
            foreach(var letra in _materia.Descricao)
            {
                if(!char.IsWhiteSpace(letra) && !char.IsLetter(letra))
                {
                    return true;
                }
            }
            return false;
        }
    }
}
