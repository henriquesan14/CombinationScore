using Newtonsoft.Json;
using ScoreCombination.Core.DTOs;
using ScoreCombination.Core.Entities;
using ScoreCombination.Core.Repositories;
using ScoreCombination.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ScoreCombination.Application.Services
{
    public class RequestCombinationService : IRequestCombinationService
    {
        private readonly IRequestCombinationRepository _repository;
        private int currentValue;
        private readonly IList<int> arrayCombination = new List<int>();

        public RequestCombinationService(IRequestCombinationRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseCombinationDTO> GetCombination(RequestCombinationDTO request)
        {
            var combination = GenerateCombination(request);
            var hasCombination = combination.Sum().Equals(request.Target);
            var response = new ResponseCombinationDTO
            {
                HasCombination = hasCombination,
                Combination = hasCombination ? combination : null
            };
            var entity = new Core.Entities.ScoreCombinationEntity {
                Request = JsonConvert.SerializeObject(request),
                Response = JsonConvert.SerializeObject(response)
            };
            await _repository.CreateAsync(entity);
            return response;
        }

        public async Task<List<ResponseScoreCombinationDTO>> GetRequestsCombinations(RequestFilterCombinationsDTO filter)
        {
            var dateInitial = Convert.ToDateTime(filter.DateInitial);
            var dateFinal = Convert.ToDateTime(filter.DateFinal);
            Expression<Func<ScoreCombinationEntity, bool>> predicate = a => a.CreatedAt >= dateInitial && a.CreatedAt <= dateFinal;
            var list = await _repository.GetAsync(predicate);
            var listDto = new List<ResponseScoreCombinationDTO>();
            foreach(var l in list) {
                var dto = new ResponseScoreCombinationDTO(l);
                listDto.Add(dto);
            }
            return listDto;
        }

        private int[] GenerateCombination(RequestCombinationDTO request)
        {
            currentValue = request.Target;
            var ordered = request.Sequence.OrderByDescending(x => x).ToArray();
            foreach (var ord in ordered)
                ProcessValue(ord);
            return arrayCombination.OrderBy(x => x).ToArray();
        }

        private void ProcessValue(int ord)
        {
            var val = currentValue - ord;
            if (val >= 0)
            {
                currentValue = val;
                arrayCombination.Add(ord);
                ProcessValue(ord);
            }
        }

    }
}
