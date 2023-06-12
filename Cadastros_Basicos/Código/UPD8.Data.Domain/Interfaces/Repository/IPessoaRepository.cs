using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Filter;

namespace UPD8.Data.Domain.Interfaces.Repository
{
    public interface IPessoaRepository : IBaseRepository<PessoaEntity, long>
    {
        Task<IEnumerable<PessoaEntity>> GetListAsync(PessoaFilter dto);

    }
}
