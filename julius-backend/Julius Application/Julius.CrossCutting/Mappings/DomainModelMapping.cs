using AutoMapper;
using Julius.Domain.Domains;
using Julius.Domain.Models;

namespace Julius.CrossCutting.Mappings
{
    public class DomainModelMapping : Profile
    {
        public DomainModelMapping()
        {
            CreateMap<Expense, ExpenseModel>()
                .ReverseMap();

            CreateMap<Expense, CreateExpenseModel>()
                .ReverseMap();
        }
    }
}
