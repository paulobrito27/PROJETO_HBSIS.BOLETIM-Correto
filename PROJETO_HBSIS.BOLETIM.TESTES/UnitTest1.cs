using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Validation;
using System;
using System.Text.RegularExpressions;

namespace PROJETO_HBSIS.BOLETIM.TESTES
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void ValidaNomeAluno_true()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2001 - 01 - 01T00:00:00"),
                Cpf = "11111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidaNomeAluno_False()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste1",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2001 - 01 - 01T00:00:00"),
                Cpf = "11111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsFalse(result.IsValid);
        }
        [TestMethod]
        public void ValidaSobrenomeAluno_True()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2001 - 01 - 01T00:00:00"),
                Cpf = "11111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidaSobrenomeAluno_False()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "",
                DataNascimento = DateTime.Parse("2001 - 01 - 01T00:00:00"),
                Cpf = "11111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidaDataNascimento_True()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("1980 - 10 - 27T00:00:00"),
                Cpf = "11111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidaDataNascimento_Nulo_False()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("0001 - 01 - 01T00:00:00"),
                Cpf = "11111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidaDataNascimento_MaiorQueDefinida_False()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2003 - 01 - 01T00:00:00"),
                Cpf = "11111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidaTamanhoePadraoCpfInformado_True()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2000 - 01 - 01T00:00:00"),
                Cpf = "11111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsTrue(result.IsValid);
        }

        [TestMethod]
        public void ValidaCpfInformado_Tamanho_False()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2000 - 01 - 01T00:00:00"),
                Cpf = "1111111111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidaCpfInformado_Formato_False()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2000 - 01 - 01T00:00:00"),
                Cpf = "1111111A111"
            };
            var result = new AlunoValidator().Valida(aluno);
            Assert.IsFalse(result.IsValid);
        }

        [TestMethod]
        public void ValidaCpfFormatado_true()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2000 - 01 - 01T00:00:00"),
                Cpf = "00734849974"
            };
            var cpfFormatado = new AlunoValidator().FormataCPF(aluno);

            bool match = Regex.IsMatch(cpfFormatado, @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
            Assert.IsTrue(match);
        }

        [TestMethod]
        public void ValidaCpfFormatado_false()
        {
            Aluno aluno = new Aluno()
            {
                Nome = "teste",
                Sobrenome = "teste",
                DataNascimento = DateTime.Parse("2000 - 01 - 01T00:00:00"),
                Cpf = "007348499a4"
            };
            var cpfFormatado = new AlunoValidator().FormataCPF(aluno);

            bool match = Regex.IsMatch(cpfFormatado, @"^\d{3}\.\d{3}\.\d{3}\-\d{2}$");
            Assert.IsFalse(match);
        }
    }
}

