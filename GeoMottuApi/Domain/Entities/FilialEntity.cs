using GeoMottuApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoMottuApi.Domain.Entities
{
    [Table("TB_GEOMOTTU_FILIAL")]
    public class FilialEntity
    {
        [Key]
        [Column("ID_FILIAL")]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        [Column("NM_FILIAL")]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        [Column("PAIS_FILIAL")]
        public PaisesFiliais PaisFilial { get; set; }

        [Required]
        [StringLength(50)]
        [Column("ESTADO_FILIAL")]
        public string Estado { get; set; }

        [Required]
        [StringLength(150)]
        [Column("ENDERECO_FILIAL")]
        public string Endereco { get; set; }

        public DateTime CriadoEm { get; set; } = DateTime.Now;
    }
}
