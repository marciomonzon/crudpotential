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
            try
            {
                var desenvolvedores = _context.Desenvolvedor?
                  .Where(x => x.Nome == nome)?
                  .AsNoTracking()?
                  .ToList();

                return desenvolvedores;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool VerificarSeDesenvolvedorExiste(Desenvolvedor desenvolvedor)
        {
            try
            {
                var existe = _context.Desenvolvedor?
                .Any(x => x.Nome == desenvolvedor.Nome
                && x.Idade == desenvolvedor.Idade
                && x.Sexo == desenvolvedor.Sexo);

                if (existe != null)
                    return (bool)existe;

                return false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void AtualizarDesenvolvedor(int id, Desenvolvedor desenvolvedor)
        {
            try
            {
                var desenvContext = _context.Desenvolvedor.Find(id);

                desenvContext.DataDeNascimento = desenvolvedor.DataDeNascimento;
                desenvContext.DesenvolvedorId = id;
                desenvContext.Hobby = desenvolvedor.Hobby;
                desenvContext.Nome = desenvolvedor.Nome;
                desenvContext.Idade = desenvolvedor.Idade;
                desenvContext.Sexo = desenvolvedor.Sexo;

                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ExcluirDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            try
            {
                if (desenvolvedor.DesenvolvedorId == 0)
                    throw new Exception("Código inválido para a exlcusão");

                _context.Desenvolvedor.Remove(desenvolvedor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void InserirDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            try
            {
                if (desenvolvedor == null)
                {
                    throw new Exception("Nenhum desenvolvedor para inserir!");
                }

                _context.Desenvolvedor.Add(desenvolvedor);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Desenvolvedor> ObterDesenvolvedores(string nome = "", int? page = null, int? pageSize = 5)
        {
            try
            {
                var desenvolvedor = _context.Desenvolvedor
                    ?.AsNoTracking()
                    ?.ToList();

                return desenvolvedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Desenvolvedor ObterDesenvolvedorPorId(int id)
        {
            try
            {
                if (id == 0)
                    throw new Exception("Código inválido para a consulta!");

                var desenvolvedor = _context.Desenvolvedor
                        ?.Where(x => x.DesenvolvedorId == id)
                        ?.AsNoTracking()
                        ?.FirstOrDefault();

                return desenvolvedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<Desenvolvedor> RetornarPesquisaComPaginacao(int? page = null, int? pageSize = 5)
        {
            try
            {
                var comPaginacao = _context.Desenvolvedor?
                  .Skip(((int)page - 1) * (int)pageSize)
                  .Take((int)pageSize)
                  .ToList();

                return comPaginacao;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
