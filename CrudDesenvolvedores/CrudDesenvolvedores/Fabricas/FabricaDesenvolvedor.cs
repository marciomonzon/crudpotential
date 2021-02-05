using CrudDesenvolvedores.DTO;
using CrudDesenvolvedores.Extensions;
using CrudDesenvolvedores.Models;

namespace CrudDesenvolvedores.Fabricas
{
    public static class FabricaDesenvolvedor
    {
        public static Desenvolvedor NovoObjetoDesenvolvedor(DtoDesenvolvedor dto)
        {
            var desenv = new Desenvolvedor()
            {
                Nome = dto.Nome,
                DataDeNascimento = dto.DataDeNascimento.StringToDate(),
                Hobby = dto.Hobby,
                Idade = dto.Idade.ConverterParaInteiro(),
                Sexo = dto.Sexo
            };

            return desenv;
        }
    }
}
