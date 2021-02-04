using CrudDesenvolvedores.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CrudDesenvolvedores.Dados
{
    public class DesenvolvedorContext : DbContext
    {
        public DesenvolvedorContext(DbContextOptions<DesenvolvedorContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)// previne de configurar duas vezes
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=postgres;Username=postgres;Password=123456");
            }
        }

        public DbSet<Desenvolvedor> Desenvolvedor { get; set; }
    }
}
