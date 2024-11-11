using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Contracts.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DataGridStarostin.Standart.ApplicantManager.Tests
{
    /// <summary>
    /// Тесты для класса <see cref="ApplicantManager"/>.
    /// </summary>
    public class ApplicantManagerTest
    {
        private readonly IApplicantManager applicantManager;
        private readonly Mock<IApplicantStorage> applicantStorageMock;
        private readonly Mock<ILogger> loggerMock;

        private readonly Task<IReadOnlyCollection<Applicant>> filledDefaultApplicantList;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicantManagerTest"/>.
        /// </summary>
        public ApplicantManagerTest()
        {
            applicantStorageMock = new Mock<IApplicantStorage>();

            loggerMock = new Mock<ILogger>();
            loggerMock.Setup(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));

            applicantManager = new ApplicantManager(applicantStorageMock.Object,
                Mock.Of<ILogger>());
        }

        /// <summary>
        /// Тест: Метод <see cref="ApplicantManager.AddAsync"/>
        /// </summary>
        [Fact]
        public async Task AddShouldWork()
        {
            // Arrange
            var model = new Applicant
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Male,
                Birthday = DateTime.Now,
                Education = Education.FTPT,
                Math = 52,
                Russian = 52,
                ComputerScience = 52,
            };
            applicantStorageMock.Setup(x => x.AddAsync(It.IsAny<Applicant>()))
                .ReturnsAsync(model);

            // Act
            var result = await applicantManager.AddAsync(model);

            // Asset
            result.Should().NotBeNull()
                .And.Be(model);
            applicantStorageMock.Verify(x => x.AddAsync(It.Is<Applicant>(y => y.Id == model.Id)),
                Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Тест: Метод <see cref="ApplicantManager.DeleteAsync"/>
        /// </summary>
        [Fact]
        public async Task DeleteShouldWork()
        {
            // Arrange
            var model = new Applicant
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Male,
                Birthday = DateTime.Now,
                Education = Education.FTPT,
                Math = 52,
                Russian = 52,
                ComputerScience = 52,
            };
            applicantStorageMock.Setup(x => x.DeleteAsync(It.IsAny<Guid>()))
                .ReturnsAsync(true);

            // Act
            var result = await applicantManager.DeleteAsync(model.Id);

            // Asset
            result.Should()
                .Be(true);

            applicantStorageMock.Verify(x => x.DeleteAsync(It.Is<Guid>(y => y == model.Id)),
                Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();

            loggerMock.Verify(x => x.Log(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
            loggerMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Изменение данных в хранилище
        /// </summary>
        [Fact]
        public async Task EditAsyncShouldWork()
        {
            // Arrange
            var model = new Applicant
            {
                Id = Guid.NewGuid(),
                Name = $"Name{Guid.NewGuid():N}",
                Gender = Gender.Male,
                Birthday = DateTime.Now,
                Education = Education.FTPT,
                Math = 52,
                Russian = 52,
                ComputerScience = 52,
            };
            applicantStorageMock.Setup(x => x.EditAsync(It.IsAny<Applicant>()));

            // Act
            await applicantManager.EditAsync(model);

            applicantStorageMock.Verify(x => x.EditAsync(It.Is<Applicant>(y => y.Id == model.Id)),
                 Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();

            loggerMock.Verify(x => x.Log(LogLevel.Information, It.IsAny<EventId>(), It.IsAny<It.IsAnyType>(), null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()),
                Times.Once);
            loggerMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Получение данные из хранилища, если их нет
        /// </summary>
        [Fact]
        public async Task GetAllAsyncShouldReturnEmpty()
        {
            // Arrange
            applicantStorageMock.Setup(x => x.GetAllAsync());

            // Act
            var result = await applicantManager.GetAllAsync();

            // Assert
            result.Should().BeNull();

            applicantStorageMock.Verify(x => x.GetAllAsync(), Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();

            loggerMock.VerifyNoOtherCalls();
        }
    }
}
