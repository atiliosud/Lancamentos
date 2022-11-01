using Lancamentos.Business.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Lancamentos.Repository.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<CaixaDiario>().HasKey(c => c.Id);

            builder.Entity<CaixaDiario>()
                .HasOne(b => b.Colaborador)
                .WithMany()
                .HasForeignKey(ub => ub.ColaboradorId)
                .OnDelete(DeleteBehavior.ClientNoAction);


            builder.Entity<Lancamento>().HasKey(c => c.Id);
            builder.Entity<Lancamento>()
                .HasOne(b => b.CaixaDiario)
                .WithMany(x=>x.Lancamentos)
                .HasForeignKey(ub => ub.CaixaDiarioId)
                .OnDelete(DeleteBehavior.ClientNoAction);

            base.OnModelCreating(builder);
        }

        public DbSet<Lancamento> Lancamentos { get; set; }
        public DbSet<CaixaDiario> CaixaDiarios { get; set; }
    }
}