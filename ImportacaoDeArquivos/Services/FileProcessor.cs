using ImportacaoDeArquivos.Interfaces;
using ImportacaoDeArquivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Services
{
    public class FileProcessor : IFileProcessor
    {
        private readonly IFileReader<Cliente> _clienteReader;
        private readonly IFileReader<Conta> _contaReader;
        private readonly IFileReader<Plastico> _plasticoReader;
        private readonly IFileReader<Transacao> _transacaoReader;

        private readonly IDataRepository<Cliente> _clienteRepository;
        private readonly IDataRepository<Conta> _contaRepository;
        private readonly IDataRepository<Plastico> _plasticoRepository;
        private readonly IDataRepository<Transacao> _transacaoRepository;

        public FileProcessor(
            IFileReader<Cliente> clienteReader,
            IFileReader<Conta> contaReader,
            IFileReader<Plastico> plasticoReader,
            IFileReader<Transacao> transacaoReader,
            IDataRepository<Cliente> clienteRepository,
            IDataRepository<Conta> contaRepository,
            IDataRepository<Plastico> plasticoRepository,
            IDataRepository<Transacao> transacaoRepository)
        {
            _clienteReader = clienteReader;
            _contaReader = contaReader;
            _plasticoReader = plasticoReader;
            _transacaoReader = transacaoReader;
            _clienteRepository = clienteRepository;
            _contaRepository = contaRepository;
            _plasticoRepository = plasticoRepository;
            _transacaoRepository = transacaoRepository;
        }

        public void Process(string directoryPath)
        {
            // Processamento dos arquivos
            var clientes = _clienteReader.ReadFile(Path.Combine(directoryPath, "Cliente_20140220.txt"));
            var contas = _contaReader.ReadFile(Path.Combine(directoryPath, "Conta_20140220.txt"));
            var plasticos = _plasticoReader.ReadFile(Path.Combine(directoryPath, "Plastico_20140220.txt"));
            var transacoes = _transacaoReader.ReadFile(Path.Combine(directoryPath, "Transacao_20140220.txt"));

            // Inserir ou atualizar os dados no banco
            foreach (var cliente in clientes) _clienteRepository.Insert(cliente);
            foreach (var conta in contas) _contaRepository.Insert(conta);
            foreach (var plastico in plasticos) _plasticoRepository.Insert(plastico);
            foreach (var transacao in transacoes) _transacaoRepository.Insert(transacao);
        }
    }


}
