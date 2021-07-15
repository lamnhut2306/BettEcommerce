using AutoMapper;
using FluentAssertions;
using Moq;
using Microsoft.EntityFrameworkCore;
using Rookie.MyEcommerce.Business;
using Rookie.MyEcommerce.Business.Interfaces;
using Rookie.MyEcommerce.Business.Services;
using Rookie.MyEcommerce.Contracts.Dtos;
using Rookie.MyEcommerce.Entities.ProductAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Rookie.MyEcommerce.UnitTests.Business
{
    public class CategoryServiceShould
    {
        private readonly CategoryService _categoryService;
        private readonly Mock<IBaseRepository<Category>> _categoryRepository;
        private readonly IMapper _mapper;

        public CategoryServiceShould()
        {
            _categoryRepository = new Mock<IBaseRepository<Category>>();

            var config = new MapperConfiguration(cfg => cfg.AddProfile<AutoMapperProfile>());
            _mapper = config.CreateMapper();

            _categoryService = new CategoryService(
                    _categoryRepository.Object,
                    _mapper
                );
        }

        [Fact]
        public async Task GetAsyncShouldReturnNullAsync()
        {
            var id = Guid.NewGuid();
            _categoryRepository
                  .Setup(x => x.GetByIdAsync(id))
                  .Returns(Task.FromResult<Category>(null));

            var result = await _categoryService.GetByIdAsync(id);

            result.Should().BeNull();
        }

        [Fact]
        public async Task GetAsyncShouldReturnObjectAsync()
        {
            var entity = new Category()
            {
                Description = "code",
                Id = Guid.NewGuid(),
                Name = "Name"
            };

            _categoryRepository.Setup(x => x.GetByIdAsync(entity.Id)).Returns(Task.FromResult(entity));
            var result = await _categoryService.GetByIdAsync(entity.Id);

            result.Should().NotBeNull();
            _categoryRepository.Verify(mock => mock.GetByIdAsync(entity.Id), Times.Once());
        }

        [Fact]
        public async Task AddCategoryShouldThrowExceptionAsync()
        {
            Func<Task> act = async () => await _categoryService.AddAsync(null);

            await act.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task AddCategoryShouldBeSuccessfullAsync()
        {
            var category = new Category()
            {
                Description = "code",
                Id = Guid.NewGuid(),
                Name = "name"
            };

            var categoryDto = new CategoryDto()
            {
                Description = "code",
                Id = Guid.NewGuid(),
                Name = "name"
            };
            _categoryRepository.Setup(x => x
                .GetByAsync(It.IsAny<Expression<Func<Category, bool>>>(), It.IsAny<string>()))
                .Returns(Task.FromResult<Category>(category));

            _categoryRepository.Setup(x => x.AddAsync(It.IsAny<Category>())).Returns(Task.FromResult(category));

            var result = await _categoryService.AddAsync(categoryDto);

            result.Should().NotBeNull();

            _categoryRepository.Verify(mock => mock.AddAsync(It.IsAny<Category>()), Times.Once());
        }

        [Fact]
        public async Task DeleteCategoryShouldReturnNullAsync()
        {
            var id = Guid.NewGuid();
            _categoryRepository.Setup(x => x.DeleteAsync(id)).Throws(new DbUpdateException());

            Func<Task> act = async () => await _categoryService.DeleteAsync(id);

            await act.Should().ThrowAsync<DbUpdateException>();
        }

        /*[Fact]
        public async Task DeleteCategoryShouldBeSuccessfullAsync()
        {
            var id = Guid.NewGuid();
            var category = new Category()
            {
                Id = id,
                Name = "name",
                Description = "desc"
            };
           // _categoryRepository.Setup(x => x.DeleteAsync(id)).Returns(Task.FromResult());

            Func<Task> act = async () => await _categoryService.DeleteAsync(id);

            act.Should().BeNull();
        }*/

        /*[Fact]
        public async Task UpdateCategoryShouldThrowExceptionAsync()
        {

        }*/

        /*[Fact]
        public async Task UpdateCategoryShouldBeSuccessfullAsync()
        {

        }

        [Fact]
        public async Task GetAllCategoryShouldSuccessfullAsync()
        {
            var categories = new List<Category>
            {
                new Category() { Id = Guid.NewGuid(), Name = "name", Description = "description" },
                new Category() { Id = Guid.NewGuid(), Name = "name", Description = "description" }
            };

            _categoryRepository.SetupGet(x => x.Entities.ap)
        }*/
    }
}
