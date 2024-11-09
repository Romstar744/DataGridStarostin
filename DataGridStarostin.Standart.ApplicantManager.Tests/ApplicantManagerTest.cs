using System;
using System.Threading.Tasks;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Contracts.Models;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using Xunit;

namespace DataGridStarostin.Standart.ApplicantManager.Tests
{
    public class ApplicantManagerTest
    {
        private readonly IApplicantManager applicantManager;
        private readonly Mock<IApplicantStorage> applicantStorageMock;
        private readonly Mock<ILogger> loggerMock;

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
    }
}
