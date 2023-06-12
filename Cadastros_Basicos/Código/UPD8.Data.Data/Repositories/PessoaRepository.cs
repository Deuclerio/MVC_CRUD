using LinqKit;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Filter;
using UPD8.Data.Domain.Interfaces.Repository;

namespace UPD8.Data.Data.Repositories
{
    public class PessoaRepository : BaseRepository<PessoaEntity, long>, IPessoaRepository
    {
        public PessoaRepository(UPD8Context context) : base(context) { }

        public async Task<IEnumerable<PessoaEntity>> GetListAsync(PessoaFilter dto)
        {
            var predCast = PredicateBuilder.True<PessoaEntity>();

            //if (dto.Status != null)
            //    predCast = predCast.And(x => x.Status == dto.Status);

            if (!string.IsNullOrWhiteSpace(dto.Nome))
                predCast = predCast.And(x => x.Nome.Contains(dto.Nome));

            return await _context.ColorEntity.Where(predCast).AsNoTracking().ToListAsync();
        }
    }
}
