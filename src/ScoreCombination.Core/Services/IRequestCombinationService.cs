using ScoreCombination.Core.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScoreCombination.Core.Services
{
    public interface IRequestCombinationService
    {
        Task<ResponseCombinationDTO> GetCombination(RequestCombinationDTO request);
        Task<List<ResponseScoreCombinationDTO>> GetRequestsCombinations(RequestFilterCombinationsDTO filter);
    }
}
