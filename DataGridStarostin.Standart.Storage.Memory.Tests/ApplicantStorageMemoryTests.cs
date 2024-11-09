using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataGridStarostin.Standart.Contracts;
using DataGridStarostin.Standart.Contracts.Models;
using FluentAssertions;
using Xunit;

namespace DataGridStarostin.Standart.Storage.Memory.Tests
{
    /// <summary>
    /// <see cref="MemoryApplicantStorage"/>
    /// </summary>
    public class ApplicantStorageMemoryTests
    {
        private readonly IApplicantStorage applicantStorage;

        public ApplicantStorageMemoryTests()
        {
            applicantStorage = new MemoryApplicantStorage();
        }

        /// <summary>
        /// При пустом списке нет ошибок <see cref="IApplicantStorage.GetAllAsync"/>
        /// </summary>
        [Fact]
        public async Task GetAllShouldNotThrow()
        {
            // Act
            Func<Task> act = () => applicantStorage.GetAllAsync();

            // Assert
            await act.Should().NotThrowAsync();
        }


        /// <summary>
        /// Получает пустой список <see cref="IApplicantStorage.GetAllAsync"/>
        /// </summary>
        [Fact]
        public async Task GetAllShouldReturnEmpty()
        {
            // Act
            var result = await applicantStorage.GetAllAsync();

            // Assert
            result.Should()
            .NotBeNull()
            .And.BeEmpty();
        }

        [Fact]
        public async Task AddShouldReturnValue()
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

            // Act
            var result = await applicantStorage.AddAsync(model);

            // Assert
            result.Should().NotBeNull()
                .And.BeEquivalentTo(new
                {
                    model.Id,
                    model.Gender,
                });
        }
    }
}
