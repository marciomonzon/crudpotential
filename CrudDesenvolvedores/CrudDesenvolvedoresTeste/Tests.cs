using CrudDesenvolvedores.Dados;
using CrudDesenvolvedores.Models;
using CrudDesenvolvedores.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CrudDesenvolvedoresTeste
{
    public class Tests
    {
        private readonly DesenvolvedorContext _context;
        private readonly ServicoDesenvolvedor _servico;
        public Tests()
        {
            _context = ApplicationContextTest.GetContext();
            _servico = new ServicoDesenvolvedor(_context);
        }

        private void InserirDesenvolvedor()
        {
            var desenvolvedor = new Desenvolvedor()
            {
                Nome = "Marcio Teste",
                Sexo = "M",
                Idade = 50,
                Hobby = "Nenhum",
                DataDeNascimento = DateTime.Now
            };

            _servico.InserirDesenvolvedor(desenvolvedor);
        }

        private void ExcluirDesenvolvedor(List<Desenvolvedor> devs)
        {
            foreach (var item in devs)
            {
                _servico.ExcluirDesenvolvedor(item.DesenvolvedorId);
            }
        }

        [Fact(DisplayName = "Obter_Desenvolvedores")]
        public void Test_Obter_Desenvolvedores()
        {
            InserirDesenvolvedor();

            var desenvolvedores = _servico.ObterDesenvolvedores();

            // nao pode ser null o objeto
            Assert.NotNull(desenvolvedores);

            // tem regristos
            Assert.Single(desenvolvedores);

            ExcluirDesenvolvedor(desenvolvedores);
        }

    }
}
