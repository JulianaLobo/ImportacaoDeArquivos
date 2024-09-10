using ImportacaoDeArquivos.Interfaces;
using ImportacaoDeArquivos.Models;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Repositories
{
    public class ClienteRepository : IDataRepository<Cliente>
    {
        private readonly string _connectionString;

        public ClienteRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Insert(Cliente entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO tbcliente (cpfcli, nomcli, endcli, baicli, cidcli, sigest, datcad) VALUES (@cpfcli, @nomcli, @endcli, @baicli, @cidcli, @sigest, @datcad)", connection);
                command.Parameters.AddWithValue("@cpfcli", entity.CPF);
                command.Parameters.AddWithValue("@nomcli", entity.Nome);
                command.Parameters.AddWithValue("@endcli", entity.Endereco);
                command.Parameters.AddWithValue("@baicli", entity.Bairro);
                command.Parameters.AddWithValue("@cidcli", entity.Cidade);
                command.Parameters.AddWithValue("@sigest", entity.Estado);
                command.Parameters.AddWithValue("@datcad", entity.DataCadastro);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Cliente entity)
        {
            // Implementar lógica de atualização
        }

        public Cliente GetById(int id)
        {
            // Implementar lógica de obtenção por ID
            return null;
        }

        public IEnumerable<Cliente> GetAll()
        {
            // Implementar lógica de obtenção de todos os registros
            return new List<Cliente>();
        }
    }

}
