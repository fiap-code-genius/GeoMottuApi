using GeoMottuApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoMottuApi.Domain.Entities
{
    [Table("TB_GEOMOTTU_PATIO")]
    public class PatioEntity
    {
        [Key]
        [Column("ID_PATIO")]
        public int Id { get; set; }

        [Required]
        [Column("CAPC_PATIO")]
        public int CapacidadeTotal { get; set; }

        [Column("REFERENCIA_PATIO")]
        [MaxLength(100)]
        public string? LocalizacaoReferencia { get; set; }

        [Required]
        [Column("TIPO_PATIO")]
        [MaxLength(50)]
        public TipoPatio tipoPatio { get; set; }

    }
}
