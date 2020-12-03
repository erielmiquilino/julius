using AutoMapper;
using Julius.Domain.Domains;
using Julius.Domain.DTOs;

namespace Julius.CrossCutting.Mappings
{
    public class DomainDtoMapping : Profile
    {
        public DomainDtoMapping()
        {
            CreateMap<MonthDto, Expense>()
                .ReverseMap();

            CreateMap<ExpenseDto, Expense>()
                .ReverseMap();
        }
    }
}
