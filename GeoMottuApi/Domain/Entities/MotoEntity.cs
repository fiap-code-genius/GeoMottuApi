using GeoMottuApi.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GeoMottuApi.Domain.Entities
{
    [Table("TB_GEOMOTTU_MOTO")]
    public class MotoEntity
    {
        [Key]
        [Column("ID_MOTO")]
        public int Id { get; set; }

        [StringLength(10)]
        [Column("PLACA_MOTO")]
        public string? Placa { get; set; } = string.Empty;

        [StringLength(17)]
        [Column("CHASSI_MOTO")]
        [Required]
        public string Chassi { get; set; }

        [Column("CD_IOT_PLACA")]
        [MaxLength(50)]
        public string? CodPlacaIot { get; set; } = string.Empty;

        [Required]
        [Column("MOTO_MODELO")]
        public ModeloMoto Modelo { get; set; }

        [Required]
        [Column("MOTOR_MOTO")]
        public int Motor { get; set; }

        [Column("MOTO_PROPRIETARIO")]
        [StringLength(150)]
        public string? Proprietario { get; set; } = string.Empty;

        public DateTime CriadoEm { get; set; } = DateTime.Now;

    }
}
