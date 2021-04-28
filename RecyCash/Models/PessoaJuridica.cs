using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace RecyCash.Models
{
    [Table("T_RC_PESSOA_JURIDICA")]
    public class PessoaJuridica
    {
        [Required]
        [Column("CD_CODIGO")]
        [Key, ForeignKey("Pessoa")]
        public int CdPessoa { get; set; }

        [Required]
        [Column("NM_RAZAO_SOCIAL")]
        public string RazaoSocial { get; set; }

        [Required]
        [Column("VL_CNPJ")]
        public string Cnpj { get; set; }

        [Required]
        [Column("DT_ABERTURA", TypeName = "Date")]
        public DateTime DtAbertura { get; set; }

        public virtual Pessoa Pessoa { get; set; }
    }
}
