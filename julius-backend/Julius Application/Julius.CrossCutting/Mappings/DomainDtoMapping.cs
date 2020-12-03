using AutoMapper;
using Julius.Domain.Domains;
using Julius.Domain.DTOs;
using Julius.Domain.Models;

namespace Julius.CrossCutting.Mappings
{
    public class DomainDtoMapping : Profile
    {
        public DomainDtoMapping()
        {
            CreateMap<MonthDto, Expense>()
                .ReverseMap();
        }
    }
}
