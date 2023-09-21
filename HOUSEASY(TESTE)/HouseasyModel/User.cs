using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HouseasyModel
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "Este campo deve ter 14 Caracteres.")]
        public string CPF { get; set; } = "";

        [Required(ErrorMessage = "O Nome é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Este campo deve ter no minimo 5 e no máximo 150 Caracteres.")]
        public string Nome { get; set; } = "";

        [StringLength(14, ErrorMessage = "Este campo deve ter no máximo 14 Caracteres.")]
        public string? Telefone { get; set; }

        [StringLength(30, ErrorMessage = "Este campo é obrigatório.")]
        public string? Ocupação { get; set; }

        [Required(ErrorMessage = "O Celular é obrigatório.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "Este campo deve ter 15 Caracteres.")]
        public string Celular { get; set; } = "";

        [StringLength(150, ErrorMessage = "Este campo deve ter no máximo 150 Caracteres.")]
        public string? Email { get; set; } = "";

        [Required(ErrorMessage = "O Logradouro é obrigatório.")]
        [StringLength(150, MinimumLength = 5, ErrorMessage = "Este campo deve ter no minimo 5 e no máximo 150 Caracteres.")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O Número é obrigatório.")]
        [StringLength(10, MinimumLength = 1, ErrorMessage = "Este campo deve ter no minimo 1 e no máximo 10 Caracteres.")]
        public string Numero { get; set; }

        [StringLength(100, ErrorMessage = "Este campo deve ter no máximo 100 Caracteres.")]
        public string? Complemento { get; set; }

        [Required(ErrorMessage = "O Bairro é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Este campo deve ter no minimo 2 e no máximo 50 Caracteres.")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatório.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Este campo deve ter no minimo 2 e no máximo 100 Caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [StringLength(2, MinimumLength = 2, ErrorMessage = "Este campo deve ter 2 Caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [StringLength(9, MinimumLength = 9, ErrorMessage = "Este campo deve ter 9 Caracteres.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "A Data de Nascimento é obrigatório.")]
        public DateTime DataNascimento { get; set; }
        public DateTime DataInclusao { get; set; }
        public DateTime? DataAlteracao { get; set; }
    }
}
