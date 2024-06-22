using JobsServis.Repsatory;
using Jops.Context.Database;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jops.Domain.Entity;

namespace Company.Test
{
    public class Advertisement_Test
    {
        private DbContextOptions<JopsContext> CreateNewContextOptions()
        {
            return new DbContextOptionsBuilder<JopsContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
        }

        private IDbContextPool<JopsContext> GetDbContextFactoryAsync(DbContextOptions<JopsContext> options)
        {
            var mockDbFactory = new Mock<DbContextFactory<JopsContext>>();
            mockDbFactory.Setup(f => f.CreateDbContext()).Returns(() => new JopsContext(options));
            return (IDbContextPool<JopsContext>)mockDbFactory.Object;

        }

        [Fact]
        public async Task Save_ShouldAddCompany()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new AdvertisementRep((JopsContext)factory);
            var advertisement = new Advertisement { Discerioton = "Discerioton" };

            // Act
            await service.Creat(advertisement);

            // Assert
            using var context = new JopsContext(options);
            var fetchedadvertisement = await context.advertisements.FirstOrDefaultAsync(a => a.Discerioton == "Discerioton");
            Assert.NotNull(fetchedadvertisement);
        }

        [Fact]
        public async Task Get_ShouldReturnvenueById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new AdvertisementRep((JopsContext)factory);
            var advertisement = new Advertisement { Discerioton = "Discerioton" };
            await service.Creat(advertisement);

            // Act
            var fetchedadvertisement = await service.GetById(advertisement.Id);

            // Assert
            Assert.NotNull(fetchedadvertisement);
            Assert.Equal(advertisement.Discerioton, fetchedadvertisement.Discerioton);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllcompany()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new AdvertisementRep((JopsContext)factory);
            var advertisement1 = new Advertisement { Id=1, Discerioton = "Discerioton" };
            var advertisement2 = new Advertisement { Id = 1, Discerioton = "Discerioton" };

            await service.Creat(advertisement1);
            await service.Creat(advertisement2);

            // Act
            var advertisement = await service.GetAll();

            // Assert
            Assert.Equal(2, advertisement.Count);
        }

        [Fact]
        public async Task Delete_ShouldRemoveVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new AdvertisementRep((JopsContext)factory);
            var advertisement2 = new Advertisement { Id = 1, Discerioton = "Discerioton" };
            await service.Creat(advertisement2);

            // Act
            await service.Delete(advertisement2);

            // Assert
            using var context = new JopsContext(options);
            var deletedadvertisement = await context.advertisements.FindAsync(advertisement2.Id);
            Assert.Null(deletedadvertisement);
        }


        [Fact]
        public async Task Update_ShouldModifyVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new AdvertisementRep((JopsContext)factory);
            var advertisement = new Advertisement { Id = 1, Discerioton = "Discerioton" };
            await service.Creat(advertisement);

            // Act
            advertisement.Discerioton = "Discerioton";

            await service.Update(advertisement);

            // Assert
            using var context = new JopsContext(options);
            var updatedadvertisement = await context.advertisements.FindAsync(advertisement.Id);
            Assert.Equal("Updated Company", updatedadvertisement.Discerioton);

        }



        [Fact]
        public async Task GetList_ShouldReturnAuthorsByName()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new AdvertisementRep((JopsContext)factory);
            var advertisement1 = new Advertisement { Id = 1, Discerioton = "Discerioton" };
            var advertisement2 = new Advertisement { Id = 1, Discerioton = "Discerioton" };

            await service.Creat(advertisement1);
            await service.Creat(advertisement2);

            // Act
            var advertisement = await service.Sarche(advertisement1.Id);

            // Assert
            Assert.Equal(2, advertisement.Count);
        }




    }
}
