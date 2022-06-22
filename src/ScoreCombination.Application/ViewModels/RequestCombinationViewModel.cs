using System;

namespace ScoreCombination.Application.ViewModels
{
    public class RequestCombinationViewModel
    {
        public int Id { get; set; }
        public int Targe { get; set; }
        public int[] Sequence { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
