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

        [Required]
        [Column("TP_TIPO")]
        public PessoaTipo Tipo { get; set; }

        [Required]
        [Column("DS_LOGRADOURO")]
        public string Logradouro { get; set; }

        [Required]
        [Column("DS_NUMERO")]
        public string Numero { get; set; }

        [Column("DS_COMPLEMENTO")]
        public string Complemento { get; set; }

        [Required]
        [Column("DS_CIDADE")]
        public string Cidade { get; set; }

        [Required]
        [Column("DS_ESTADO")]
        public string Estado { get; set; }

        [Required]
        [Column("VL_CEP")]
        public string Cep { get; set; }

        [Column("VL_LATITUDE")]
        public string Latitude { get; set; }

        [Column("VL_LONGITUDE")]
        public string Longitude { get; set; }
    }
}
