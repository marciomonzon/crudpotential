using CrudDesenvolvedores.Dados;
using CrudDesenvolvedores.Models;
using CrudDesenvolvedores.Services;
using System;
using System.Collections.Generic;
using System.Linq;
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

        [Fact(DisplayName = "Obter_Desenvolvedores")]
        public void Test_Obter_Desenvolvedores()
        {
            InserirDesenvolvedor();

            var desenvolvedores = _servico.ObterDesenvolvedores();

            // nao pode ser null o objeto
            Assert.NotNull(desenvolvedores);

            // tem regristos
            Assert.Single(desenvolvedores);
        }

        [Fact(DisplayName = "Excluir_Desenvolvedor")]
        public void Test_Excluir_Desenvolvedor()
        {
            InserirDesenvolvedor();
            var desenvolvedor = _servico.ObterDesenvolvedores()?.FirstOrDefault();

            // nao pode ser null o objeto
            Assert.NotNull(desenvolvedor);

            _servico.ExcluirDesenvolvedor(desenvolvedor.DesenvolvedorId);
        }

        [Fact(DisplayName = "Atualizar_Desenvolvedor")]
        public void Teste_Atualizar_Desenvolvedor()
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

            var desenvolvedores = _servico.ObterDesenvolvedores();

            if (desenvolvedores?.Count > 0)
            {
                var desenvolvedorParaAtualizar = desenvolvedores.FirstOrDefault();
                desenvolvedorParaAtualizar.Nome = "Marcio Atualizado";
                _servico.AtualizarDesenvolvedor(desenvolvedorParaAtualizar);
            }

            // nao pode ser null o objeto
            Assert.NotNull(desenvolvedores);
        }
    }
}
