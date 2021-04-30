using Xunit;
using System.Linq;
using DTIServices = Teste_DTI.Services;
using DTIModels = Teste_DTI.Models;

namespace Teste_DTI.UnitTest.Services.Client.ClientService.ClientServiceClass
{
    public class Edit
    {
        private readonly DTIServices.ClientService _sut;

        public Edit()
        {
            _sut = new DTIServices.ClientService();
        }

        [Fact]
        public void WhenGivenClient_ShouldChangeClientWithSameId()
        {
            //Arrange
            var client = _sut.Get().FirstOrDefault();
            client.Nome = "Novo Nome";
            client.Endereco = "Novo Endereco";
            client.Celular = "Novo Celular";
            client.CPF = "Novo CPF";
            client.Email = "Novo Email";

            //Act
            var editClient = _sut.Edit(client);

            //Assert
            var existingClient = _sut.GetById(editClient.Id);
            Assert.Equal(existingClient, editClient);
        }

        [Fact]
        public void WhenCalled_ShouldVerifyIfReturnIsClient()
        {
            //Arrange
            var client = _sut.Get().FirstOrDefault();
            client.Nome = "Novo Nome";
            client.Endereco = "Novo Endereco";
            client.Celular = "Novo Celular";
            client.CPF = "Novo CPF";
            client.Email = "Novo Email";

            //Act
            var editClient = _sut.Edit(client);

            //Assert
            Assert.IsType<DTIModels.Client>(editClient);
        }
    }
}
