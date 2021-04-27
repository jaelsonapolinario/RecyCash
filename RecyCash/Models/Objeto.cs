using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecyCash.Models
{
    [Table("T_RC_OBJETO")]
    public class Objeto
    {
        [Key]
        [Column("CD_CODIGO")]
        public int Codigo { get; set; }

        [Column("NM_NOME")]
        [Required]
        public string Nome { get; set; }
    }
}
