using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CrudDesenvolvedores.Dados;
using CrudDesenvolvedores.Enums;
using CrudDesenvolvedores.Models;
using CrudDesenvolvedores.Resolvedores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CrudDesenvolvedores.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DevelopersController : ControllerBase
    {
        private readonly DesenvolvedorContext _context;

        public DevelopersController(DesenvolvedorContext context)
        {
            _context = context;
        }

        private IActionResult PesquisarPeloNome(string nome)
        {
            var retorno = _context.Desenvolvedor?
           .Where(x => x.Nome == nome)?.ToList();

            if (retorno?.Count == 0)
            {
                return NotFound($"Nenhum desenvolvedor encontrado! Nome informado: {nome}");
            }
            return Ok(retorno);
        }

        private List<Desenvolvedor> RetornarComPaginacao(int? page = null, int? pageSize = 5)
        {
            var comPaginacao = _context.Desenvolvedor?
                  .Skip(((int)page - 1) * (int)pageSize)
                  .Take((int)pageSize)
                  .ToList();

            return comPaginacao;
        }

        [HttpGet]
        public IActionResult ObterDesenvolvedores(string nome = "", int? page = null, int? pageSize = 5)
        {
            try
            {
                var desenvolvedores = new List<Desenvolvedor>();

                if (!string.IsNullOrEmpty(nome.Trim()))
                    return PesquisarPeloNome(nome);

                if (page > 0)
                    desenvolvedores = RetornarComPaginacao(page, pageSize);
                else
                    desenvolvedores = _context.Desenvolvedor?.ToList();

                if (desenvolvedores?.Count > 0)
                    return Ok(desenvolvedores);

                return NotFound("Nenhum desenvolvedor cadastrado!");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }

        [HttpGet("{id}")]
        public IActionResult ObterDesenvolvedorPorId(int id)
        {
            try
            {
                var desenvolvedores = _context.Desenvolvedor
                    ?.Where(x => x.DesenvolvedorId == id)
                    ?.ToList();
                if (desenvolvedores?.Count > 0)
                {
                    return Ok(desenvolvedores);
                }
                return NotFound($"Nenhum desenvolvedor cadastrado! Parametro informado: {id}");
            }
            catch (Exception)
            {
                return StatusCode(500);
            }
        }
    }
}