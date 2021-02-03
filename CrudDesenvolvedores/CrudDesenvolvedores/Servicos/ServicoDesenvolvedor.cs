using CrudDesenvolvedores.Dados;
using CrudDesenvolvedores.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CrudDesenvolvedores.Services
{
    public class ServicoDesenvolvedor
    {
        public Desenvolvedor ObterDesenvolvedor(DesenvolvedorContext contexto, int idDesenvolvedor)
        {
            var desenvolvedor = contexto.Desenvolvedor
                    ?.Where(x => x.DesenvolvedorId == idDesenvolvedor)
                    ? .AsNoTracking()
                    ?.FirstOrDefault();

            return desenvolvedor;
        }

        public List<Desenvolvedor> ObterDesenvolvedoresPeloNome(DesenvolvedorContext contexto, string nome)
        {
            var desenvolvedores = contexto.Desenvolvedor?
          .Where(x => x.Nome == nome)?
          .AsNoTracking()?
          .ToList();

            return desenvolvedores;
        }

        public bool VerificarSeDesenvolvedorExiste(DesenvolvedorContext contexto, Desenvolvedor desenvolvedor)
        {
            var existe = contexto.Desenvolvedor?
                .Any(x => x.Nome == desenvolvedor.Nome
                && x.Idade == desenvolvedor.Idade
                && x.Sexo == desenvolvedor.Sexo);

            if (existe != null)
                return (bool)existe;

            return false;
        }
    }
}
