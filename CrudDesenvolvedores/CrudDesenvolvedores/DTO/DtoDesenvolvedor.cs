using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDesenvolvedores.DTO
{
    public class DtoDesenvolvedor
    {
        /// <summary>
        /// Código
        /// </summary>
        public int DesenvolvedorId { get; set; }

        /// <summary>
        /// Nome do Desenvolvedor
        /// </summary>
        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false)]
        public string Nome { get; set; }

        /// <summary>
        /// Sexo do Desenvolvedor
        /// </summary>
        [Required(ErrorMessage = "O campo Sexo é obrigatório", AllowEmptyStrings = false)]
        public string Sexo { get; set; }

        /// <summary>
        /// Idade do Desenvolvedor
        /// </summary>
        [Required(ErrorMessage = "O campo Idade é obrigatório", AllowEmptyStrings = false)]
        public string Idade { get; set; }

        /// <summary>
        /// Hobby do Desenvolvedor
        /// </summary>
        [StringLength(100, ErrorMessage = "O tamanho máximo permitido é 100 caracteres")]
        public string Hobby { get; set; }

        /// <summary>
        /// Data de Nascimento do Desenvolvedor
        /// </summary>
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório", AllowEmptyStrings = false)]
        public string DataDeNascimento { get; set; }
    }
}
