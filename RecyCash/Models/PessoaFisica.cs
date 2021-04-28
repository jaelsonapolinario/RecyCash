using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using RecyCash.Models.Enums;

namespace RecyCash.Models
{
    [Table("T_RC_PESSOA_FISICA")]
    
    public class PessoaFisica
    {
        [Required]
        [Column("CD_PESSOA")]
        [Key, ForeignKey("Pessoa")]
        public int CdPessoa { get; set; }

        [Required]
        [Column("VL_CPF")]
        public string Cpf { get; set; }

        [Required]
        [Column("DT_NASCIMENTO", TypeName="Date")]
        public DateTime DtNascimento { get; set; }

        [Required]
        [Column("GENERO")]
        public Genero Genero { get; set; }

        
        public virtual Pessoa Pessoa { get; set; }
    }
}
