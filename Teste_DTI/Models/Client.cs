using Newtonsoft.Json;
using System;

namespace Teste_DTI.Models
{
    public class Client
    {
        public Guid Id { get; set; }

        public string Nome { get; set; }

        public string Endereco { get; set; }

        public string Celular { get; set; }

        public string Email { get; set; }

        public string CPF { get; set; }
    }
}
