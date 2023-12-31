using Moq;
using SortedCodingTest.App;
using SortedCodingTest.App.Exceptions;
using SortedCodingTest.Rainfall.Client;
using SortedCodingTest.Rainfall.Client.Models;

namespace SortedCodingTest.Tests
{
    public class RainfallServiceTests
    {
        private readonly Mock<IRainfallApiClient> _clientMock;

        public RainfallServiceTests()
        {
            _clientMock = new Mock<IRainfallApiClient>();
        }

        [Theory]
        [MemberData(nameof(GetConstructorTestData))]
        public void RainfallService_CheckConstructorParameters(IRainfallApiClient rainfallApiClient, Type exceptionType)
        {
            Assert.Throws(exceptionType, () => new RainfallService(rainfallApiClient));
        }

        [Fact]
        public async Task GetRainfallReadingsAsync_EmptyResponse_ThrowsException()
        {
            _clientMock
                .Setup(x => x.GetRainfallReadingsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(new List<RainfallApiReading>());

            var service = new RainfallService(_clientMock.Object);

            await Assert.ThrowsAsync<AppException>(() => service.GetRainfallReadingsAsync(1, 1));
        }

        [Fact]
        public async Task GetRainfallReadingsAsync_ResponseContainsElements_ReturnsDto()
        {
            var response = new List<RainfallApiReading> { new RainfallApiReading { DateTime = DateTime.Now, Value = 1 } };

            _clientMock
                .Setup(x => x.GetRainfallReadingsAsync(It.IsAny<int>(), It.IsAny<int>()))
                .ReturnsAsync(response);

            var service = new RainfallService(_clientMock.Object);

            var result = await service.GetRainfallReadingsAsync(1, 1);

            Assert.Equal(response.Count, result.Count);
        }

        public static IEnumerable<object?[]> GetConstructorTestData()
        {
            return new List<object?[]>
            {
                new object?[] { null, typeof(ArgumentNullException) }
            };
        }
    }
}