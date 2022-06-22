using AutoMapper;
using MediatR;
using ScoreCombination.Core.Entities;
using ScoreCombination.Core.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace ScoreCombination.Application.Commands.CreateRequestCombination
{
    public class CreateRequestCombinationCommandHandler : IRequestHandler<CreateRequestCombinationCommand, int>
    {
        private readonly IRequestCombinationRepository _repository;
        private readonly IMapper _mapper;

        public CreateRequestCombinationCommandHandler(IRequestCombinationRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<int> Handle(CreateRequestCombinationCommand request, CancellationToken cancellationToken)
        {
            var requestCombination = _mapper.Map<RequestCombination>(request);
            await _repository.CreateAsync(requestCombination);
            return requestCombination.Id;
        }
    }
}
