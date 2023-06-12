using Microsoft.EntityFrameworkCore;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Mapping;

namespace UPD8.Data.Data.Context
{
    public class UPD8Context
    {
        public UPD8Context(DbContextOptions<UPD8Context> options) : base(options) { }

        public DbSet<PessoaEntity> PessoasEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder model)
        {
            base.OnModelCreating(model);
            model.Entity<PessoaEntity>(new PessoaMap().Configure);

        }

        public async Task<int> SaveChangesAsync<TKey>()
        {
            var entities = ChangeTracker.Entries().Where(x => x.Entity is BaseEntity<TKey> && (x.State == EntityState.Added || x.State == EntityState.Modified));

            foreach (var entity in entities)
            {
                var now = DateTime.Now;

                if (entity.State == EntityState.Added)
                {
                    ((BaseEntity<TKey>)entity.Entity).DateRegister = now;
                }

                ((BaseEntity<TKey>)entity.Entity).DateLastUpdate = now;
            }


            return await base.SaveChangesAsync();
        }

    }
}