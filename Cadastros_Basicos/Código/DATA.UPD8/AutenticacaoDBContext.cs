using Domain.UPD8.Entidades;
using Microsoft.EntityFrameworkCore;


namespace DATA.UPD8
{
    public class AutenticacaoDBContext : DbContext
    {

        public AutenticacaoDBContext(DbContextOptions<AutenticacaoDBContext> options) : base(options)
        {
        }

        public DbSet<Autenticacao> Autenticacoes { get; set; }
       
    }
}