using Microsoft.EntityFrameworkCore;
using RecyCash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RecyCash.DAL
{
    public class MyDbContext : DbContext
    {
        public virtual DbSet<Coleta> Coleta { get; set; }
        public virtual DbSet<Objeto> Objeto { get; set; }
        public virtual DbSet<Pessoa> Pessoa { get; set; }
        public virtual DbSet<PessoaFisica> PessoaFisica { get; set; }
        public virtual DbSet<PessoaJuridica> PessoaJuridica { get; set; }

        public MyDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
