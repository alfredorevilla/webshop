using FluentAssertions;
using FakeItEasy;
using System;
using AlfredoRevillaWebshop.Repositories.Implementations;
using Xunit;
using AlfredoRevillaWebshop.Repositories.Models;
using System.Threading.Tasks;

namespace AlfredoRevillaWebshop.Tests
{
    public class InMemoryProductsRepositoryTests
    {
        private InMemoryProductsRepository _repository;

        [Fact]
        public async Task First_id_should_be_set_to_1()
        {
            _repository = new InMemoryProductsRepository();
            (await _repository.CreateAsync(new CreateProductRepositoryModel { })).Should().Be(1);
        }
    }
}