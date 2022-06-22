using Confitec.Infrastructure.Context;
using Confitec.Infrastructure.Repositories;
using ScoreCombination.Core.Entities;
using ScoreCombination.Core.Repositories;

namespace ScoreCombination.Infrastructure.Repositories
{
    public class RequestCombinationRepository : BaseRepository<RequestCombination>, IRequestCombinationRepository
    {
        public RequestCombinationRepository(ScoreCombinationContext context) : base(context)
        {

        }
    }
}
