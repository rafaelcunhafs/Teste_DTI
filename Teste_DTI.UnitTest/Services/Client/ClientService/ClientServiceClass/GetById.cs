using System;
using System.Linq;
using Xunit;
using DTIServices = Teste_DTI.Services;
using DTIModels = Teste_DTI.Models;

namespace Teste_DTI.UnitTest.Services.Client.ClientService.ClientServiceClass
{
    public class GetById
    {
        private readonly DTIServices.ClientService _sut;

        public GetById()
        {
            _sut = new DTIServices.ClientService();
        }

        [Fact]
        public void WhenCalled_ShouldReturnClientWithSameId()
        {
            //Arrange
            var clientId = _sut.Get().First().Id;

            //Act
            var client = _sut.GetById(clientId);

            //Assert
            Assert.Equal(clientId, client.Id);
        }

        [Fact]
        public void WhenCalled_CanReturnNull()
        {
            //Arrange
            var clientId = Guid.NewGuid();

            //Act
            var client = _sut.GetById(clientId);

            //Assert
            Assert.Null(client);
        }

        [Fact]
        public void WhenExistClient_ShouldVerifyIfReturnIsClient()
        {
            //Arrange
            var clientId = _sut.Get().First().Id;

            //Act
            var client = _sut.GetById(clientId);

            //Assert
            Assert.IsType<DTIModels.Client>(client);
        }
    }
}
