using System;
using System.Collections.Generic;

namespace LegacySystem
{
    // Classe Cliente
    class Cliente
    {
        public int Id { get; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public DateTime Cadastro { get; } = DateTime.Now;

        public Cliente(int id, string nome, string email)
        {
            Id = id;
            Nome = nome;
            Email = email;
        }

        public void AtualizarNome(string novoNome)
        {
            if (!string.IsNullOrWhiteSpace(novoNome))
            {
                Nome = novoNome;
            }
        }

        public void AtualizarEmail(string novoEmail)
        {
            if (!string.IsNullOrWhiteSpace(novoEmail) && novoEmail.Contains("@"))
            {
                Email = novoEmail;
            }
        }

        public void ExibirDados()
        {
            Console.WriteLine($"Id: {Id} Nome: {Nome} Email: {Email} Cadastro: {Cadastro}");
        }
    }

    // Classe Transacao
    class Transacao
    {
        public int Id { get; }
        public decimal Valor { get; }
        public DateTime Data { get; } = DateTime.Now;
        public string Descricao { get; }

        public Transacao(int id, decimal valor, string descricao)
        {
            Id = id;
            Valor = valor;
            Descricao = descricao;
        }

        public void ExibirTransacao()
        {
            Console.WriteLine($"Id: {Id} Valor: {Valor} Descricao: {Descricao} Data: {Data}");
        }
    }

    // Classe SistemaTransacoes
    class SistemaTransacoes
    {
        private readonly List<Transacao> _listaDeTransacoes = new List<Transacao>();

        public void AdicionarTransacao(int id, decimal valor, string descricao)
        {
            var transacao = new Transacao(id, valor, descricao);
            _listaDeTransacoes.Add(transacao);
        }

        public void ExibirTransacoes()
        {
            foreach (var transacao in _listaDeTransacoes)
            {
                transacao.ExibirTransacao();
            }
        }
    }

    // Classe SistemaCliente
    class SistemaCliente
    {
        private readonly List<Cliente> _clientes = new List<Cliente>();

        public IReadOnlyList<Cliente> Clientes => _clientes;

        public void AdicionarCliente(int id, string nome, string email)
        {
            _clientes.Add(new Cliente(id, nome, email));
        }

        public void RemoverCliente(int id)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            if (cliente != null)
            {
                _clientes.Remove(cliente);
            }
        }

        public void ExibirTodosOsClientes()
        {
            foreach (var cliente in _clientes)
            {
                cliente.ExibirDados();
            }
        }

        public void AtualizarNomeCliente(int id, string novoNome)
        {
            var cliente = _clientes.Find(c => c.Id == id);
            cliente?.AtualizarNome(novoNome);
        }
    }

    // Classe Relatorio
    class Relatorio
    {
        public void GerarRelatorioClientes(List<Cliente> clientes)
        {
            foreach (var cliente in clientes)
            {
                Console.WriteLine($"Cliente: {cliente.Nome} | Email: {cliente.Email}");
            }
        }
    }
}
