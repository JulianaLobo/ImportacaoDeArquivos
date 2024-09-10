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
    public class ContaRepository : IDataRepository<Conta>
    {
        private readonly string _connectionString;

        public ContaRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Insert(Conta entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO tbconta (nrocta, cpfcli, vlrlim, diaven) VALUES (@nrocta, @cpfcli, @vlrlim, @diaven)", connection);
                command.Parameters.AddWithValue("@nrocta", entity.NumeroConta);
                command.Parameters.AddWithValue("@cpfcli", entity.CPF);
                command.Parameters.AddWithValue("@vlrlim", entity.ValorLimite);
                command.Parameters.AddWithValue("@diaven", entity.DiaVencimento);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Conta entity)
        {
            // Implementar lógica de atualização
        }

        public Conta GetById(int id)
        {
            // Implementar lógica de obtenção por ID
            return null;
        }

        public IEnumerable<Conta> GetAll()
        {
            // Implementar lógica de obtenção de todos os registros
            return new List<Conta>();
        }
    }

}
