using Moq;
using ScoreCombination.Application.Services;
using ScoreCombination.Core.DTOs;
using ScoreCombination.Core.Entities;
using ScoreCombination.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ScoreCombination.UnitTests.Services
{
    public class RequestCombinationServiceTests
    {
        private readonly Mock<IRequestCombinationRepository> _repository;

        public RequestCombinationServiceTests()
        {
            _repository = new Mock<IRequestCombinationRepository>();
        }

        [Fact]
        public async Task GetCombination_Executed_ReturnCombination()
        {

            var request = new RequestCombinationDTO { 
                Sequence = new int[] { 5,20,2,1 },
                Target = 47
            };
            var requestCombinationService = new RequestCombinationService(_repository.Object);
            //Act
            var response = await requestCombinationService.GetCombination(request);

            //Assert
            Assert.NotNull(response);
            Assert.True(response.HasCombination);
            Assert.NotNull(response.Combination);
            _repository.Verify(pr => pr.CreateAsync(It.IsAny<ScoreCombinationEntity>()), Times.Once);
        }

        [Fact]
        public async Task GetScoresCombinations_Executed_ReturnCombination()
        {

            var request = new RequestFilterCombinationsDTO
            {
                DateInitial = DateTime.Now.AddDays(-5).ToString("yyyy-MM-dd HH:mm:ss"),
                DateFinal = DateTime.Now.AddDays(2).ToString("yyyy-MM-dd HH:mm:ss")
            };
            var responseMoq = new List<ScoreCombinationEntity>() { 
                new ScoreCombinationEntity
                {
                    Request = "teste",
                    Response = "teste",
                    CreatedAt = DateTime.Now
                }
            };
            var requestCombinationService = new RequestCombinationService(_repository.Object);
            _repository.Setup(r => r.GetAsync(It.IsAny<Expression<Func<ScoreCombinationEntity, bool>>>())).ReturnsAsync(responseMoq);
            //Act
            var response = await requestCombinationService.GetRequestsCombinations(request);

            //Assert
            Assert.NotNull(response);
            _repository.Verify(pr => pr.GetAsync(It.IsAny<Expression<Func<ScoreCombinationEntity, bool>>>()), Times.Once);
        }
    }
}
