using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore;
using Jops.Context.Database;
using Moq;
using Jops.Domain.Entity;
using JobsServis.Repsatory;

namespace Company.Test;
    public class Company_Test
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
            var service = new CompanyRep((JopsContext)factory);
            var company = new Jops.Domain.Entity.Company { Name = "company1" };

            // Act
            await service.Creat(company);

            // Assert
            using var context = new JopsContext(options);
            var fetchedcompany = await context.companies.FirstOrDefaultAsync(a => a.Name == "venue1");
            Assert.NotNull(fetchedcompany);
        }

        [Fact]
        public async Task Get_ShouldReturnvenueById()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new CompanyRep((JopsContext)factory);
            var company = new Jops.Domain.Entity.Company { Name = "company", Locaton = "123abc" };
            await service.Creat(company);

            // Act
            var fetchedcompany = await service.GetById(company.Id);

            // Assert
            Assert.NotNull(fetchedcompany);
            Assert.Equal(company.Name, fetchedcompany.Name);
        }

        [Fact]
        public async Task GetAll_ShouldReturnAllcompany()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new CompanyRep((JopsContext)factory);
            var company1 = new Jops.Domain.Entity.Company { Name = "company1", Locaton = "123abc" };
            var company2 = new Jops.Domain.Entity.Company { Name = "company2", Locaton = "123abc" };

            await service.Creat(company1);
            await service.Creat(company2);

            // Act
            var company = await service.GetAll();

            // Assert
            Assert.Equal(2, company.Count);
        }

        [Fact]
        public async Task Delete_ShouldRemoveVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new CompanyRep((JopsContext)factory);
            var company = new Jops.Domain.Entity.Company { Name = "company", Locaton = "123abc" };
            await service.Creat(company);

            // Act
            await service.Delete(company);

            // Assert
            using var context = new JopsContext(options);
            var deletedvenue = await context.companies.FindAsync(company.Id);
            Assert.Null(deletedvenue);
        }


        [Fact]
        public async Task Update_ShouldModifyVenue()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new CompanyRep((JopsContext)factory);
            var company = new Jops.Domain.Entity.Company { Name = "company", Locaton = "123abc" };
            await service.Creat(company);

            // Act
            company.Name = "Updated Company";

            await service.Update(company);

// Assert
            using var context = new JopsContext(options);
            var updatedvenue = await context.companies.FindAsync(company.Id);
            Assert.Equal("Updated Company", updatedvenue.Name);

        }



        [Fact]
        public async Task GetList_ShouldReturnAuthorsByName()
        {
            // Arrange
            var options = CreateNewContextOptions();
            var factory = GetDbContextFactoryAsync(options);
            var service = new CompanyRep((JopsContext)factory);
            var company1 = new Jops.Domain.Entity.Company { Id=1, Name = "company1", Locaton = "123abc" };
            var company2 = new Jops.Domain.Entity.Company { Id=1, Name = "company1", Locaton = "123abc" };

            await service.Creat(company1);
            await service.Creat(company2);
            // Act
            var company = await service.Sarche(company1.Id);

            // Assert
            Assert.Equal(2, company.Count);
        }





    }
