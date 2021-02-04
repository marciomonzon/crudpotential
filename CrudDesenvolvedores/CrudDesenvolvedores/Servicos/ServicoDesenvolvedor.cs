using CrudDesenvolvedores.Dados;
using CrudDesenvolvedores.Interfaces;
using CrudDesenvolvedores.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudDesenvolvedores.Services
{
    public class ServicoDesenvolvedor : IServicoDesenvolvedor
    {
        private readonly DesenvolvedorContext _context;
        public ServicoDesenvolvedor(DesenvolvedorContext context)
        {
            _context = context;
        }

        public List<Desenvolvedor> ObterDesenvolvedoresPeloNome(string nome)
        {
            var desenvolvedores = _context.Desenvolvedor?
          .Where(x => x.Nome == nome)?
          .AsNoTracking()?
          .ToList();

            return desenvolvedores;
        }

        public bool VerificarSeDesenvolvedorExiste(Desenvolvedor desenvolvedor)
        {
            var existe = _context.Desenvolvedor?
                .Any(x => x.Nome == desenvolvedor.Nome
                && x.Idade == desenvolvedor.Idade
                && x.Sexo == desenvolvedor.Sexo);

            if (existe != null)
                return (bool)existe;

            return false;
        }

        public void AtualizarDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            _context.Entry(desenvolvedor).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public void ExcluirDesenvolvedor(int id)
        {
            var desenvolvedor = ObterDesenvolvedorPorId(id);

            if (desenvolvedor != null)
            {
                _context.Desenvolvedor.Remove(desenvolvedor);
                _context.SaveChanges();
            }
        }

        public void InserirDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            _context.Desenvolvedor.Add(desenvolvedor);
            _context.SaveChanges();
        }

        public List<Desenvolvedor> ObterDesenvolvedores(string nome = "", int? page = null, int? pageSize = 5)
        {
            var desenvolvedor = _context.Desenvolvedor
                    ?.AsNoTracking()
                    ?.ToList();

            return desenvolvedor;
        }

        public Desenvolvedor ObterDesenvolvedorPorId(int id)
        {
            var desenvolvedor = _context.Desenvolvedor
                    ?.Where(x => x.DesenvolvedorId == id)
                    ?.AsNoTracking()
                    ?.FirstOrDefault();

            return desenvolvedor;
        }

        public List<Desenvolvedor> RetornarPesquisaComPaginacao(int? page = null, int? pageSize = 5)
        {
            var comPaginacao = _context.Desenvolvedor?
                  .Skip(((int)page - 1) * (int)pageSize)
                  .Take((int)pageSize)
                  .ToList();

            return comPaginacao;
        }
    }
}
