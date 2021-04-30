using System.Collections.Generic;
using Xunit;
using DTIServices = Teste_DTI.Services;
using DTIModels = Teste_DTI.Models;

namespace Teste_DTI.UnitTest.Services.Client.ClientService.ClientServiceClass
{
    public class Get
    {
        private readonly DTIServices.ClientService _sut;

        public Get()
        {
            _sut = new DTIServices.ClientService();
        }

        [Fact]
        public void WhenCalled_ShouldReturnsAllClients()
        {
            //Arrange

            //Act
            var clients = _sut.Get();

            //Assert
            Assert.NotNull(clients);
        }

        [Fact]
        public void WhenCalled_ShouldReturnListOfClients()
        {
            //Arrange

            //Act
            var clients = _sut.Get();

            //Assert
            Assert.IsType<List<DTIModels.Client>>(clients);
        }
    }
}
