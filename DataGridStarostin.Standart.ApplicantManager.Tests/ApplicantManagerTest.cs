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
        private readonly Mock<ILogger<IApplicantManager>> loggerMock;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicantManagerTest"/>.
        /// </summary>
        public ApplicantManagerTest()
        {
            applicantStorageMock = new Mock<IApplicantStorage>();
            loggerMock = new Mock<ILogger<IApplicantManager>>();

            loggerMock.Setup(x => x.Log(LogLevel.Information,
                It.IsAny<EventId>(),
                It.IsAny<It.IsAnyType>(),
                null,
                It.IsAny<Func<It.IsAnyType, Exception, string>>()));

            applicantManager = new ApplicantManager(applicantStorageMock.Object, loggerMock.Object);
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

            loggerMock.Verify(x => x.Log
            (LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((state, t) => state.ToString().Contains(nameof(IApplicantManager.AddAsync))),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
            loggerMock.VerifyNoOtherCalls();

            applicantStorageMock.Verify(x => x.AddAsync(It.Is<Applicant>(y => y.Id == model.Id)),
                Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// 
        /// </summary>
        [Fact]
        public async Task EditShouldWork()
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
            applicantStorageMock.Setup(x => x.EditAsync(It.IsAny<Applicant>())).Returns(Task.CompletedTask);

            // Act
            await applicantManager.EditAsync(model);

            // Asset
            loggerMock.Verify(x => x.Log
            (LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((state, t) => state.ToString().Contains(nameof(IApplicantManager.EditAsync))),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
            loggerMock.VerifyNoOtherCalls();

            applicantStorageMock.Verify(x => x.EditAsync(It.Is<Applicant>(y => y.Id == model.Id)),
                Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Тест: Метод <see cref="ApplicantManager.AddAsync"/>
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
            applicantStorageMock.Setup(x => x.DeleteAsync(model.Id))
                .ReturnsAsync(true);

            // Act
            var result = await applicantManager.DeleteAsync(model.Id);

            // Asset
            result.Should().BeTrue();

            loggerMock.Verify(x => x.Log
            (LogLevel.Information,
            It.IsAny<EventId>(),
            It.Is<It.IsAnyType>((state, t) => state.ToString().Contains(nameof(IApplicantManager.DeleteAsync))),
            null,
            It.IsAny<Func<It.IsAnyType, Exception, string>>()),
            Times.Once);
            loggerMock.VerifyNoOtherCalls();

            applicantStorageMock.Verify(x => x.DeleteAsync(model.Id),
                Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();

        }

        /// <summary>
        /// Тест: Метод <see cref="ApplicantManager.GetAllAsync"/>
        /// </summary>
        [Fact]
        public async Task GetAllShouldWork()
        {
            // Arrange
            var applicants = new List<Applicant>
    {
        new Applicant
        {
            Id = Guid.NewGuid(),
            Name = "Applicant1",
            Gender = Gender.Male,
            Birthday = DateTime.Now.AddYears(-20),
            Education = Education.FullTime,
            Math = 60,
            Russian = 60,
            ComputerScience = 60
        },
        new Applicant
        {
            Id = Guid.NewGuid(),
            Name = "Applicant2",
            Gender = Gender.Female,
            Birthday = DateTime.Now.AddYears(-22),
            Education = Education.Сorrespondence,
            Math = 70,
            Russian = 70,
            ComputerScience = 70
        }
    };
            applicantStorageMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(applicants);

            // Act
            var result = await applicantManager.GetAllAsync();

            // Assert
            result.Should().NotBeNull()
                .And.HaveCount(applicants.Count)
                .And.BeEquivalentTo(applicants);

            applicantStorageMock.Verify(x => x.GetAllAsync(), Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();
        }

        /// <summary>
        /// Тест: Метод <see cref="ApplicantManager.GetStatsAsync"/>
        /// </summary>
        [Fact]
        public async Task GetStatsShouldWork()
        {
            // Arrange
            var applicants = new List<Applicant>
    {
        new Applicant
        {
            Id = Guid.NewGuid(),
            Name = "Applicant1",
            Gender = Gender.Male,
            Birthday = DateTime.Now.AddYears(-20),
            Education = Education.FullTime,
            Math = 60,
            Russian = 60,
            ComputerScience = 60
        },
        new Applicant
        {
            Id = Guid.NewGuid(),
            Name = "Applicant2",
            Gender = Gender.Female,
            Birthday = DateTime.Now.AddYears(-22),
            Education = Education.Сorrespondence,
            Math = 70,
            Russian = 70,
            ComputerScience = 70
        }
    };
            applicantStorageMock.Setup(x => x.GetAllAsync())
                .ReturnsAsync(applicants);

            // Act
            var result = await applicantManager.GetStatsAsync();

            // Assert
            result.Should().NotBeNull();
            result.Count.Should().Be(applicants.Count);
            result.MaleCount.Should().Be(1);
            result.FemaleCount.Should().Be(1);
            result.FullTimeCount.Should().Be(1);
            result.СorrespondenceCount.Should().Be(1);
            result.FTPTCount.Should().Be(0);
            result.TotalScoreCount.Should().Be(2);

            applicantStorageMock.Verify(x => x.GetAllAsync(), Times.Once);
            applicantStorageMock.VerifyNoOtherCalls();
        }
    }
}
