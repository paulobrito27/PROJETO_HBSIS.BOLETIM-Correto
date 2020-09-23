using Microsoft.VisualStudio.TestTools.UnitTesting;
using PROJETO_HBSIS.BOLETIM.MODELS;
using PROJETO_HBSIS.BOLETIM.VALITATOR.Validation;
using System;

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

    }
}
