using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Result;
using System;

namespace PROJETO_HBSIS.BOLETIM.VALITATOR.Validation
{
    public class AlunoValidator
    {

        public ValidatorResult validador = new ValidatorResult();

        public ValidatorResult Valida(Aluno aluno)
        {
            //Valida Nome
            if (aluno.Nome == null)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome não pode estar vazio!");
                return validador;
            }
            if (aluno.Nome.Length < 3)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome tem que conter mais que 3 letras!");
            }
            if (aluno.Nome.Length > 40)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome não pode ter mais que 40 caracteres!");
            }
            if (ValidaSoLetras(aluno.Nome))
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo nome só poder conter letras!");
            }

            //Valida Sobrenome
            if (aluno.Sobrenome == null)
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo sobrenome não pode estar vazio!");
                return validador;
            }
            if (aluno.Sobrenome == "")
            {
                validador.IsValid = false;
                validador.Erros.Add("Campo sobrenome não pode estar vazio!");
                return validador;
            }


            //Valida Data nascimento
            if ((aluno.DataNascimento.Year > DateTime.Parse("2002-01-01T00:00:00").Year) ||  (aluno.DataNascimento.Year == DateTime.Parse("0001-01-01T00:00:00").Year) )
            {
                validador.IsValid = false;
                validador.Erros.Add("Data de nascimento não pode ser nula e nem superior a 01/01/2002!");
                return validador;
            }

            //Valida CPF
            if (aluno.Cpf.Length != 11)
            {
                validador.IsValid = false;
                validador.Erros.Add("Cpf tem que ser informado com 11 números");
                return validador;
            }
            if (ValidaSoNumeros(aluno.Cpf))
            {
                validador.IsValid = false;
                validador.Erros.Add("Cpf deve conter apenas números!");
                return validador;
            }

            return validador;
        }

        private bool ValidaSoLetras(string palavra)
        {
            foreach (var letra in palavra)
            {
                if (!char.IsWhiteSpace(letra) && !char.IsLetter(letra))
                {
                    return true;
                }
            }
            return false;
        }

        private bool ValidaSoNumeros(string palavra)
        {
            foreach (var letra in palavra)
            {
                if (!char.IsDigit(letra))
                {
                    return true;
                }
            }
            return false;
        }

        public string FormataCPF(Aluno aluno)
        {
            var cpf = aluno.Cpf.Insert(3, ".").Insert(7, ".").Insert(11, "-");

            return cpf;
        }
        public void SenhaLoginInicial(Aluno aluno)
        {
            aluno.Login = (aluno.Nome + aluno.DataNascimento.Year.ToString() );
            aluno.Password = (aluno.Nome + aluno.Cpf.Substring(0, 3));
        }
    }
}
