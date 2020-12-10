using AutoMapper;
using Julius.Domain.DTOs;
using Julius.Domain.Models;

namespace Julius.CrossCutting.Mappings
{
    public class DtoModelMapping : Profile
    {
        public DtoModelMapping()
        {
            CreateMap<MonthDto, MonthModel>()
                .ReverseMap();

            CreateMap<ExpenseDto, ExpenseModel>()
                .ReverseMap();

            CreateMap<IncomeDto, IncomeModel>()
                .ReverseMap();
        }
    }
}
