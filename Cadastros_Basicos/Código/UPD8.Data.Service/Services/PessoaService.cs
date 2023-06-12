using AutoMapper;
using UPD8.Data.Domain.DTOs;
using UPD8.Data.Domain.DTOs.Request;
using UPD8.Data.Domain.Entity;
using UPD8.Data.Domain.Filter;
using UPD8.Data.Domain.Interfaces.Repository;
using UPD8.Data.Domain.Interfaces.Services;

namespace UPD8.Data.Service.Services
{
    public class PessoaService : BaseService<PessoaEntity, long>, IPessoaService
    {

        private readonly IMapper _mapper;
        private readonly IPessoaRepository _iPessoaRepository;
        
        public Task<IEnumerable<PessoaEntity>> GetListAsync(PessoaFilter filter)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(PessoaDTO dto)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(PessoaRequestDTO dto)
        {
            throw new NotImplementedException();
        }
    }
}
