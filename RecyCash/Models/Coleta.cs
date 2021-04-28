using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace RecyCash.Models
{
    [Table("T_RC_COLETA")]
    public class Coleta
    {
        [Key]
        [Column("CD_COLETA")]
        public int Codigo { get; set; }

        [Required]
        [Column("CD_OBJETO")]
        public int CdObjeto { get; set; }

        [Required]
        [Column("CD_PESSOA_SOLICITANTE")]
        public int CdPessoaSolicitante { get; set; }

        [Required]
        [Column("CD_PESSOA_COLETOR")]
        public int CdPessoaColetor { get; set; }

        [Required]
        [Column("VL_QUANTIDADE")]
        public int Quantitdade { get; set; }

        [Required]
        [Column("VL_PESO", TypeName = "decimal(18, 3)")]
        public decimal Peso { get; set; }
    }
}
