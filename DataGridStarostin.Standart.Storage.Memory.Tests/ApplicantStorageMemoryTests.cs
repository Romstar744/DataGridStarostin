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
    /// Тесты для класса <see cref="MemoryApplicantStorage"/>
    /// </summary>
    public class ApplicantStorageMemoryTests
    {
        private readonly IApplicantStorage applicantStorage;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="ApplicantStorageMemoryTests"/>
        /// </summary>
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

        /// <summary>
        /// Тест: Метод <see cref="IApplicantStorage.AddAsync"/> должен вернуть добавленный объект.
        /// </summary>
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

        /// <summary>
        /// Удаление из хранилища
        /// </summary>
        [Fact]
        public async Task DeleteShouldReturnTrue()
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
            await applicantStorage.AddAsync(model);
            var result = await applicantStorage.DeleteAsync(model.Id);

            var nailList = await applicantStorage.GetAllAsync();
            var tryGetModel = nailList.FirstOrDefault(x => x.Id == model.Id);

            // Assert
            result.Should().BeTrue();
            tryGetModel.Should().BeNull();
        }

        /// <summary>
        /// Изменение данных в хранилище
        /// </summary>
        [Fact]
        public async Task EditShouldUpdateStorageData()
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
            await applicantStorage.AddAsync(model);
            await applicantStorage.EditAsync(model);
            var applicantList = await applicantStorage.GetAllAsync();
            var result = applicantList.FirstOrDefault(x => x.Id == model.Id);

            // Assert
            result?.Should().NotBeNull();
            result?.Id.Should().Be(model.Id);
            result?.Gender.Should().Be(Gender.Male);
        }
    }
}
