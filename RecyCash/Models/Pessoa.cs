using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RecyCash.Models.Enums;

namespace RecyCash.Models
{
    [Table("T_RC_PESSOA")]
    public class Pessoa
    {
        [Key]
        [Column("CD_CODIGO")]
        public int Codigo { get; set; }

        [Required]
        [Column("NM_NOME")]
        public string Nome { get; set; }

        [Required]
        [Column("DS_EMAIL")]
        public string Email { get; set; }

        [Required]
        [Column("VL_SENHA")]
        public string Senha { get; set; }
    }
}
