using Microsoft.EntityFrameworkCore;


namespace UPD8.Data.Domain.Entity
{
    public abstract class BaseEntity<TKey> : IdentifierEntity<TKey>
    {
        protected BaseEntity() : base() { }
        public virtual DateTime? DateRegister { get; set; }
        public virtual DateTime? DateLastUpdate { get; set; }
        public long UserDetailsRegisterId { get; set; }
        public long? UserDetailsUpdateId { get; set; }

        public void UpdateDate(EntityState state)
        {
            switch (state)
            {
                case EntityState.Added:
                case EntityState.Detached:
                    DateRegister = DateTime.Now;

                    break;
                case EntityState.Modified:
                    DateLastUpdate = DateTime.Now;

                    break;
            }
        }
    }
}
