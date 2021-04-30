using Xunit;
using DTIServices = Teste_DTI.Services;
using DTIModels = Teste_DTI.Models;

namespace Teste_DTI.UnitTest.Services.Client.ClientService.ClientServiceClass
{
    public class Create
    {
        private readonly DTIServices.ClientService _sut;

        public Create()
        {
            _sut = new DTIServices.ClientService();
        }

        [Fact]
        public void WhenGivenClient_ShouldSaveNewClientInMemory()
        {
            //Arrange
            var newClient = new DTIModels.Client() {
                Nome = "Cliente Teste",
                Endereco = "Rua Teste",
                Celular = "(31) 99999-9999",
                CPF = "111.111.111-11",
                Email = "teste@email.com"
            };

            //Act
            var createdClient = _sut.Create(newClient);

            //Assert
            var existingClient = _sut.GetById(createdClient.Id);
            Assert.Equal(existingClient, createdClient);
        }
    }
}
