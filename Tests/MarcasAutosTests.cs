using BackTest.Application.Services;
using BackTest.Domain.Entities;
using BackTest.Domain.Interfaces;
using Moq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace BackTest.Tests
{
    public class MarcasAutosTests
    {
        [Fact]
        public async Task GetAllMarcas_ReturnsMarcas()
        {
            var mockRepo = new Mock<IMarcaAutoRepository>();
            mockRepo.Setup(repo => repo.GetAllAsync())
                    .ReturnsAsync(new List<MarcaAuto> {
                    new MarcaAuto { Id = 1, Nombre = "Toyota" },
                    new MarcaAuto { Id = 2, Nombre = "Ford" }
                    });

            var service = new MarcaAutoService(mockRepo.Object);

            var result = await service.GetAllMarcasAsync();

            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
        }
    }
}
