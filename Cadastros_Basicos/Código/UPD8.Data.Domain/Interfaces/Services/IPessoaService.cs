
using UPD8.Data.Domain.DTOs;
using UPD8.Data.Domain.DTOs.Request;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Filter;

namespace UPD8.Data.Domain.Interfaces.Services
{
    public interface IPessoaService : IBaseService<PessoaEntity, long>
    {
        Task InsertAsync(PessoaDTO dto);

        Task UpdateAsync(PessoaRequestDTO dto);

        Task<IEnumerable<PessoaEntity>> GetListAsync(PessoaFilter filter);
    }
}