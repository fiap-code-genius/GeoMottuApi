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
    }
}
