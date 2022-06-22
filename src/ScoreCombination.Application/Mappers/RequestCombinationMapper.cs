using AutoMapper;
using ScoreCombination.Application.ViewModels;
using ScoreCombination.Core.Entities;

namespace ScoreCombination.Application.Mappers
{
    public class RequestCombinationMapper : Profile
    {
        public RequestCombinationMapper()
        {
            CreateMap<RequestCombination, RequestCombinationViewModel>().ReverseMap();
        }
    }
}
