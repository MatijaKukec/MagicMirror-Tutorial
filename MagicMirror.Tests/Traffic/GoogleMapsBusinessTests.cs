using MagicMirror.Business.Models;
using MagicMirror.Business.Services;
using MagicMirror.DataAccess.Entities.Traffic;
using MagicMirror.DataAccess.Repos;
using Moq;
using Xunit;

namespace MagicMirror.Tests.Traffic
{
    public class GoogleMapsBusinessTests
    {
        private ITrafficService _service;

        // Mock Data
        private const int Duration = 42;

        private const int Distance = 76;
        private const string Origin = "London, Uk";
        private const string Destination = "Leeds, Uk";

        public GoogleMapsBusinessTests()
        {
            var mockRepo = new Mock<ITrafficRepo>();
            _service = new TrafficService(mockRepo.Object);
        }

        [Fact]
        public void Can_Map_From_Entity()
        {
            // Arrange
            GoogleMapsEntity entity = GetMockEntity();

            // Act
            TrafficModel model = _service.MapFromEntity(entity);

            // Assert
            Assert.Equal(Distance, model.Distance);
            Assert.Equal(Duration, model.Duration);
            Assert.Equal(Destination, model.Destination);
            Assert.Equal(Origin, model.Origin);
        }

        private GoogleMapsEntity GetMockEntity()
        {
            var element = new Element
            {
                Distance = new Distance { Value = Distance },
                Duration = new Duration { Value = Duration },
            };

            var entity = new GoogleMapsEntity
            {
                Origin_addresses = new[] { Origin },
                Destination_addresses = new[] { Destination },
                Rows = new[]
                {
                    new Row
                    {
                        Elements = new [] {element}
                    }
                }
            };
            return entity;
        }
    }
}