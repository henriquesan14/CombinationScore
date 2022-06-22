using HotChocolate;
using ScoreCombination.Core.DTOs;
using ScoreCombination.Core.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoreCombination.API.GraphQL.Queries
{
    public class RequestCombinationQuery
    {
        public async Task<ResponseCombinationDTO> GetCombination([Service] IRequestCombinationService service, RequestCombinationDTO combination) => await service.GetCombination(combination);
        public async Task<List<ResponseScoreCombinationDTO>> GetRequestsCombinations([Service] IRequestCombinationService service, RequestFilterCombinationsDTO filter) => await service.GetRequestsCombinations(filter);
    }
}
