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

        private readonly Mock<IMarcaAutoRepository> mockRepo;
        private readonly MarcaAutoService service;

        public MarcasAutosTests()
        {
            mockRepo = new Mock<IMarcaAutoRepository>();
            service = new MarcaAutoService(mockRepo.Object);
        }

        [Fact]
        public async Task GetAllMarcas_ReturnsMarcas()
        {
            mockRepo.Setup(repo => repo.GetAllAsync())
                    .ReturnsAsync(new List<MarcaAuto>
                    {
                new MarcaAuto { Id = 1, Nombre = "Toyota" },
                new MarcaAuto { Id = 2, Nombre = "Ford" }
                    });

            var result = await service.GetAllMarcasAsync();
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Contains(result, m => m.Nombre == "Toyota");
            Assert.Contains(result, m => m.Nombre == "Ford");
        }

        [Fact]
        public async Task AddMarca_AddsMarca()
        {
            var newMarca = new MarcaAuto
            {
                Id = 3,
                Nombre = "Chevrolet",
                PaisDeOrigen = "Estados Unidos",
                Fundacion = new DateTime(1911, 11, 3),
                SitioWeb = "https://www.chevrolet.com",
                Activa = true,
                FechaCreacion = DateTime.UtcNow
            };
            await service.AddMarcaAsync(newMarca);
            mockRepo.Verify(repo => repo.AddAsync(It.Is<MarcaAuto>(m => m.Nombre == "Chevrolet")), Times.Once);
        }


        //[Fact]
        //public async Task AddMarca_AddsMarca()
        //{
        //    // Arrange: Crear una nueva marca
        //    var newMarca = new MarcaAuto
        //    {
        //        Id = 3,
        //        Nombre = "Chevrolet",
        //        PaisDeOrigen = "Estados Unidos",
        //        Fundacion = new DateTime(1911, 11, 3),
        //        SitioWeb = "https://www.chevrolet.com",
        //        Activa = true,
        //        FechaCreacion = DateTime.UtcNow
        //    };

        //    // Act: Llamar al método AddMarcaAsync
        //    await service.AddMarcaAsync(newMarca);

        //    // Assert: Verificar que el repositorio lo haya recibido
        //    mockRepo.Verify(repo => repo.AddAsync(It.Is<MarcaAuto>(m => m.Nombre == "Chevrolet")), Times.Once);
        //}
        [Fact]
        public async Task GetMarcaById_ReturnsMarca()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(new MarcaAuto { Id = 1, Nombre = "Toyota" });
            var result = await service.GetMarcaByIdAsync(1);
            Assert.NotNull(result);
            Assert.Equal(1, result.Id);
            Assert.Equal("Toyota", result.Nombre);
        }

        [Fact]
        public async Task UpdateMarca_UpdatesMarca()
        {
            var existingMarca = new MarcaAuto { Id = 1, Nombre = "Toyota", PaisDeOrigen = "Japón" };
            var updatedMarca = new MarcaAuto { Id = 1, Nombre = "Toyota Updated", PaisDeOrigen = "Japón" };
            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(existingMarca);
            await service.UpdateMarcaAsync(updatedMarca);

            mockRepo.Verify(repo => repo.UpdateAsync(It.Is<MarcaAuto>(m => m.Nombre == "Toyota Updated")), Times.Once);
        }

        [Fact]
        public async Task DeleteMarca_DeletesMarca()
        {
            mockRepo.Setup(repo => repo.GetByIdAsync(1))
                    .ReturnsAsync(new MarcaAuto { Id = 1, Nombre = "Toyota" });

            await service.DeleteMarcaAsync(1);
            mockRepo.Verify(repo => repo.DeleteAsync(1), Times.Once);
        }

    }
}
