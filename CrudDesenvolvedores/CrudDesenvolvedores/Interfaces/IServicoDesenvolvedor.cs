using CrudDesenvolvedores.Models;
using System.Collections.Generic;

namespace CrudDesenvolvedores.Interfaces
{
    public interface IServicoDesenvolvedor
    {
        List<Desenvolvedor> ObterDesenvolvedores(string nome = "", int? page = null, int? pageSize = 5);
        Desenvolvedor ObterDesenvolvedorPorId(int id);
        void InserirDesenvolvedor(Desenvolvedor desenvolvedor);
        void ExcluirDesenvolvedor(int id);
        void AtualizarDesenvolvedor(Desenvolvedor desenvolvedor);
        bool VerificarSeDesenvolvedorExiste(Desenvolvedor desenvolvedor);
        List<Desenvolvedor> ObterDesenvolvedoresPeloNome(string nome);
        List<Desenvolvedor> RetornarPesquisaComPaginacao(int? page = null, int? pageSize = 5);
    }
}
