using ScoreCombination.Core.Entities;
using System;

namespace ScoreCombination.Core.DTOs
{
    public class ResponseScoreCombinationDTO
    {
        public ResponseScoreCombinationDTO(ScoreCombinationEntity entity)
        {
            Request = entity.Request;
            Response = entity.Response;
            CreatedAt = entity.CreatedAt;
        }
        public string Request { get; set; }

        public string Response { get; set; }

        public DateTime? CreatedAt { get; set; }
    }
}
