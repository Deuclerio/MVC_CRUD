using AutoMapper;
using UPD8.Data.Domain.DTOs;
using UPD8.Data.Domain.DTOs.Request;
using UPD8.Data.Domain.Entity;

namespace UPD8.Data.Service.AutoMapper
{
    public class PessoaProfile : Profile
    {
        public PessoaProfile()
        {
            CreateMap<PessoaDTO, PessoaEntity>()
                .AfterMap((s, d) =>
                {
                    d.Nome = s.Nome;
                })
                .ReverseMap()
                .ForPath(s => s.Nome, opt => opt.MapFrom(src => src.Nome));

            CreateMap<PessoaRequestDTO, PessoaEntity>()
                .AfterMap((s, d) =>
                {
                    d.Nome = s.Nome.ToString();
                })
                .ReverseMap()
                .ForPath(s => s.Nome, opt => opt.MapFrom(src => src.Nome));
        }
    }
}