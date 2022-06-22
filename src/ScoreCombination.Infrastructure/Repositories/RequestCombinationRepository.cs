using Confitec.Infrastructure.Context;
using Confitec.Infrastructure.Repositories;
using ScoreCombination.Core.Entities;
using ScoreCombination.Core.Repositories;

namespace ScoreCombination.Infrastructure.Repositories
{
    public class RequestCombinationRepository : BaseRepository<Core.Entities.ScoreCombinationEntity>, IRequestCombinationRepository
    {
        public RequestCombinationRepository(ScoreCombinationContext context) : base(context)
        {

        }
    }
}
