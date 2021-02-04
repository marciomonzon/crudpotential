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

        [Fact(DisplayName = "ObterPorId")]
        public void Test_Obter_Por_Id()
        {
            InserirDesenvolvedor();
            var desenvolvedores = _servico.ObterDesenvolvedores();

            // tem regristos
            Assert.Single(desenvolvedores);

            if (desenvolvedores?.Count > 0)
            {
                var desenvolvedor = _servico
                    .ObterDesenvolvedorPorId(desenvolvedores.FirstOrDefault().DesenvolvedorId);

                // nao pode ser null o objeto
                Assert.NotNull(desenvolvedor);
            }
        }

        [Fact(DisplayName = "ValidarInsercaoPorNome")]
        public void Test_Validar_Insercao_Nome()
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

            Assert.NotNull(desenvolvedores);

            Assert.Contains(desenvolvedores, item => item.Nome == desenvolvedor.Nome);
        }
    }
}
