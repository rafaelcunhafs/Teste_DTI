using System.Linq;
using Xunit;
using DTIServices = Teste_DTI.Services;

namespace Teste_DTI.UnitTest.Services.Client.ClientService.ClientServiceClass
{
    public class Delete
    {
        private readonly DTIServices.ClientService _sut;

        public Delete()
        {
            _sut = new DTIServices.ClientService();
        }

        [Fact]
        public void WhenGivenClient_ShouldRemoveClientFromMemory()
        {
            //Arrange
            var clientId = _sut.Get().FirstOrDefault().Id;
            var deletedClient = _sut.GetById(clientId);

            //Act
            _sut.Delete(deletedClient);

            //Assert
            var clients = _sut.Get();
            Assert.DoesNotContain(deletedClient, clients);
        }
    }
}
