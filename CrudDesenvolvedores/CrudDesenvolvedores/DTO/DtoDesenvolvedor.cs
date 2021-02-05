using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDesenvolvedores.DTO
{
    public class DtoDesenvolvedor
    {
        public int DesenvolvedorId { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sexo é obrigatório", AllowEmptyStrings = false)]
        public string Sexo { get; set; }

        [Required(ErrorMessage = "O campo Idade é obrigatório", AllowEmptyStrings = false)]
        public string Idade { get; set; }

        [StringLength(100, ErrorMessage = "O tamanho máximo permitido é 100 caracteres")]
        public string Hobby { get; set; }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório", AllowEmptyStrings = false)]
        public string DataDeNascimento { get; set; }
    }
}
