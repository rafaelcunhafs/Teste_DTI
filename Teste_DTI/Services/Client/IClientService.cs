using System;
using System.Collections.Generic;
using Teste_DTI.Models;

namespace Teste_DTI.Services
{
    public interface IClientService
    {
        List<Client> Get();

        Client GetById(Guid id);

        Client Create(Client client);

        void Delete(Client client);

        Client Edit(Client client);
    }
}
