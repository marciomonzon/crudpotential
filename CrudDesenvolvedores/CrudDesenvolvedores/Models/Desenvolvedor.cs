using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudDesenvolvedores.Models
{
    [Table("desenvolvedor", Schema = "public")]
    public class Desenvolvedor
    {
        /// <summary>
        /// Código do Desenvolvedor
        /// </summary>
        [Key]
        [Column("desenvolvedorid")]
        public int DesenvolvedorId { get; set; }

        /// <summary>
        /// Nome do Desenvolvedor
        /// </summary>
        [Required(ErrorMessage = "O campo Nome é obrigatório", AllowEmptyStrings = false)]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "O tamanho máximo permitido é 100 caracteres")]
        [Column("nome")]
        public string Nome { get; set; }

        /// <summary>
        /// Sexo do Desenvolvedor
        /// </summary>
        [StringLength(1, MinimumLength = 1, ErrorMessage = "O tamanho máximo permitido é 1 caracter")]
        [Required(ErrorMessage = "O campo Sexo é obrigatório", AllowEmptyStrings = false)]
        [Column("sexo")]
        public string Sexo { get; set; }

        /// <summary>
        /// Idade do Desenvolvedor
        /// </summary>
        [Required(ErrorMessage = "O campo Idade é obrigatório", AllowEmptyStrings = false)]
        [Column("idade")]
        public int Idade { get; set; }

        /// <summary>
        /// Hobby do Desenvolvedor
        /// </summary>
        [StringLength(100, ErrorMessage = "O tamanho máximo permitido é 100 caracteres")]
        [Column("hobby")]
        public string Hobby { get; set; }

        /// <summary>
        /// Data de Nascimento do Desenvolvedor
        /// </summary>
        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório", AllowEmptyStrings = false)]
        [Column("datadenascimento")]
        public DateTime DataDeNascimento { get; set; }
    }
}
