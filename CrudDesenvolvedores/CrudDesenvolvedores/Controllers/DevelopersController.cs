using CrudDesenvolvedores.DTO;
using CrudDesenvolvedores.Fabricas;
using CrudDesenvolvedores.Interfaces;
using CrudDesenvolvedores.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace CrudDesenvolvedores.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class DevelopersController : ControllerBase
    {
        private readonly IServicoDesenvolvedor _servicoDesenvolvedor;

        public DevelopersController(IServicoDesenvolvedor service)
        {
            _servicoDesenvolvedor = service;
        }

        private IActionResult PesquisarPeloNome(string nome)
        {
            var retorno = _servicoDesenvolvedor
                .ObterDesenvolvedoresPeloNome(nome);

            if (retorno?.Count > 0)
                return Ok(retorno);

            return NotFound($"Nenhum desenvolvedor encontrado! Nome informado: {nome}");
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
                    desenvolvedores = _servicoDesenvolvedor.RetornarPesquisaComPaginacao(page, pageSize);
                else
                    desenvolvedores = _servicoDesenvolvedor.ObterDesenvolvedores();

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
                    .ObterDesenvolvedorPorId(id);

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
        public IActionResult InserirDesenvolvedor(DtoDesenvolvedor dto)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var desenvolvedor = FabricaDesenvolvedor.NovoObjetoDesenvolvedor(dto);

                    var existe = _servicoDesenvolvedor.
                        VerificarSeDesenvolvedorExiste(desenvolvedor);

                    if (existe)
                        return BadRequest("Este desenvolvedor já existe!");

                    _servicoDesenvolvedor.InserirDesenvolvedor(desenvolvedor);
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

                var desenvolvedorEncontrado = _servicoDesenvolvedor
                    .ObterDesenvolvedorPorId(id);

                if (desenvolvedorEncontrado != null)
                {
                    _servicoDesenvolvedor.ExcluirDesenvolvedor(id);
                    return Ok($"Desenvolvedor excluido com sucesso." +
                        $" Nome do Desenvolvedor: {desenvolvedorEncontrado.Nome}");
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
                     .ObterDesenvolvedorPorId(id);

                if (desenvolvedorEncontrado != null)
                {
                    _servicoDesenvolvedor.AtualizarDesenvolvedor(desenvolvedor);
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