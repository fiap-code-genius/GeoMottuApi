using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoMottuApi.Domain.Entities
{
    [Table("TB_GEOMOTTU_USUARIO")]
    public class UsuarioEntity
    {
        [Key]
        [Column("ID_USUARIO")]
        public int Id { get; set; }

        [Required]
        [Column("NOME_USUARIO")]
        [MinLength(3)]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "O email informado não possui um formato válido!")]
        [MaxLength(150)]
        [Column("EMAIL_FUNCIONARIO")]
        public string Email { get; set; }

        [Required]
        [Column("SENHA_FUNCIONARIO")]
        public string Senha { get; set; }

        public DateTime CadastradoEm { get; set; } = DateTime.Now;
    }
}
