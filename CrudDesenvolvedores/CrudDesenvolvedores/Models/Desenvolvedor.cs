using System;
using System.ComponentModel.DataAnnotations;

namespace CrudDesenvolvedores.Models
{
    public class Desenvolvedor
    {
        public int DesenvolvedorId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O tamanho máximo permitido é 100 caracteres")]
        public string Nome { get; set; }

        [StringLength(1, MinimumLength = 1, ErrorMessage = "O tamanho máximo permitido é 1 caracter")]
        [Required(ErrorMessage = "O campo Sexo é obrigatório", AllowEmptyStrings = false)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo Idade é obrigatório", AllowEmptyStrings = false)]
        public int Idade { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo permitido é 100 caracteres")]
        public string Hobby { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório", AllowEmptyStrings = false)]
        public DateTime DataDeNascimento { get; set; }
    }
}
