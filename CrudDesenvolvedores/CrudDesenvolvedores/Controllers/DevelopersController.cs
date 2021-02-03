using CrudDesenvolvedores.Dados;
using CrudDesenvolvedores.Models;
using CrudDesenvolvedores.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;

namespace CrudDesenvolvedores.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DevelopersController : ControllerBase
    {
        private readonly DesenvolvedorContext _context;
        private readonly ServicoDesenvolvedor _servicoDesenvolvedor;

        public DevelopersController(DesenvolvedorContext context)
        {
            _context = context;
            _servicoDesenvolvedor = new ServicoDesenvolvedor();
        }

        private IActionResult PesquisarPeloNome(string nome)
        {
            var retorno = _servicoDesenvolvedor
                .ObterDesenvolvedoresPeloNome(_context, nome);

            if (retorno?.Count > 0)
                return Ok(retorno);

            return NotFound($"Nenhum desenvolvedor encontrado! Nome informado: {nome}");
        }

        private List<Desenvolvedor> RetornarPesquisaComPaginacao(int? page = null, int? pageSize = 5)
        {
            var comPaginacao = _context.Desenvolvedor?
                  .Skip(((int)page - 1) * (int)pageSize)
                  .Take((int)pageSize)
                  .ToList();

            return comPaginacao;
        }

        // /developers
        [HttpGet]
        public IActionResult ObterDesenvolvedores(string nome = "", int? page = null, int? pageSize = 5)
        {
            try
            {
                var desenvolvedores = new List<Desenvolvedor>();

                if (!string.IsNullOrEmpty(nome.Trim()))
                    return PesquisarPeloNome(nome);

                if (page > 0)
                    desenvolvedores = RetornarPesquisaComPaginacao(page, pageSize);
                else
                    desenvolvedores = _context.Desenvolvedor?.ToList();

                if (desenvolvedores?.Count > 0)
                    return Ok(desenvolvedores);

                return NotFound("Nenhum desenvolvedor cadastrado!");
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)500 };
            }
        }

        // /developers/id
        [HttpGet("{id}")]
        public IActionResult ObterDesenvolvedorPorId(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Código deve ser maior que 0");

                var desenvolvedor = _servicoDesenvolvedor
                    .ObterDesenvolvedor(_context, id);

                if (desenvolvedor != null)
                {
                    return Ok(desenvolvedor);
                }
                return NotFound($"Nenhum desenvolvedor cadastrado! Parametro informado: {id}");
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)500 };
            }
        }

        // /developers
        [HttpPost]
        public IActionResult InserirDesenvolvedor(Desenvolvedor desenvolvedor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var existe = _servicoDesenvolvedor.
                        VerificarSeDesenvolvedorExiste(_context, desenvolvedor);

                    if (existe)
                        return BadRequest("Este desenvolvedor já existe!");

                    _context.Desenvolvedor.Add(desenvolvedor);
                    _context.SaveChanges();
                    return Ok($"O Desenvolvedor {desenvolvedor.Nome} foi cadastrado com sucesso!");
                }

                return BadRequest();
            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)500 };
            }
        }

        // /developers/id
        [HttpDelete("{id}")]
        public IActionResult ExcluirDesenvolvedor(int id)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Código deve ser maior que 0");

                var desenvolvedor = _servicoDesenvolvedor
                    .ObterDesenvolvedor(_context, id);

                if (desenvolvedor != null)
                {
                    _context.Desenvolvedor.Remove(desenvolvedor);
                    _context.SaveChanges();
                    return Ok($"Desenvolvedor excluído com sucesso. Nome do Desenvolvedor: {desenvolvedor.Nome}");
                }
                else
                    return NotFound($"Desenvolvedor não encontrado! Código informado: {id}");

            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)500 };
            }
        }

        // /developers/id
        [HttpPut("{id}")]
        public IActionResult AtualizarDesenvolvedor(int id, Desenvolvedor desenvolvedor)
        {
            try
            {
                if (id == 0)
                    return BadRequest("Código deve ser maior que 0");

                var desenvolvedorEncontrado = _servicoDesenvolvedor
                     .ObterDesenvolvedor(_context, id);

                if (desenvolvedorEncontrado != null)
                {
                    _context.Entry(desenvolvedor).State = EntityState.Modified;
                    _context.SaveChanges();
                    return Ok($"Desenvolvedor atualizado com sucesso. Nome do Desenvolvedor: {desenvolvedor.Nome}");
                }
                else
                    return NotFound($"Desenvolvedor não encontrado! Código informado: {id}");

            }
            catch (Exception ex)
            {
                return new ObjectResult(ex.Message) { StatusCode = (int)500 };
            }
        }
    }
}