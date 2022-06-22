using MediatR;

namespace ScoreCombination.Application.Commands.CreateRequestCombination
{
    public class CreateRequestCombinationCommand : IRequest<int>
    {
        public int Target { get; set; }
        public int[] Sequence { get; set; }
    }
}
