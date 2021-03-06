using System;
using System.Collections.Generic;
using System.Linq;
using Teste_DTI.Models;

namespace Teste_DTI.Services
{
    public class ClientService : IClientService
    {
        private readonly List<Client> _clients = new List<Client>()
        {
            new Client()
            {
                Id = Guid.NewGuid(),
                Nome = "Mateus César Lucas Monteiro",
                Endereco = "Rua Quatro 983, Coqueiral de Itaparica, Vila Velha, ES",
		        Celular = "27988302206",
		        Email = "mateuscesarlucasmonteiro@detorsul.com",
		        CPF = "97257185425"
            },
            new Client()
            {
                Id = Guid.NewGuid(),
                Nome = "Regina Maitê Ribeiro",
                Endereco = "Rua Doze 286, Parque das Laranjeiras, Formosa, GO",
                Celular = "61994045160",
                Email = "reginamaiteribeiro@andressamelo.com.br",
                CPF = "04334565239"
            },
            new Client()
            {
                Id = Guid.NewGuid(),
                Nome = "Murilo Matheus Francisco Farias",
                Endereco = "Rua das Acarapé 722, Ricardo de Albuquerque, Rio de Janeiro, RJ",
                Celular = "21998624961",
                Email = "murilomatheusfranciscofarias_@numero.com.br",
                CPF = "47966676790"
            },
            new Client()
            {
                Id = Guid.NewGuid(),
                Nome = "Olivia Cristiane Carvalho",
                Endereco = "Rua das Orquídeas 905, Samarita, São Vicente, SP",
                Celular = "13987197190",
                Email = "oliviacristianecarvalho_@smbcontabil.com.br",
                CPF = "10314931074"
            }
        };

        public Client Create(Client client)
        {
            client.Id = Guid.NewGuid();

            _clients.Add(client);

            return client;
        }

        public List<Client> Get()
        {
            return _clients;
        }

        public Client GetById(Guid id)
        {
            return _clients.SingleOrDefault(c => c.Id == id);
        }

        public void Delete(Client client)
        {
            _clients.Remove(client);
        }

        public Client Edit(Client client)
        {
            var existingClient = GetById(client.Id);
            existingClient.Nome = client.Nome;
            existingClient.Endereco = client.Endereco;
            existingClient.Celular = client.Celular;
            existingClient.Email = client.Email;
            existingClient.CPF = client.CPF;

            return existingClient;
        }
    }
}
