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
    public class TransacaoRepository : IDataRepository<Transacao>
    {
        private readonly string _connectionString;

        public TransacaoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Insert(Transacao entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO tbtransacao (nrocta, nropla, vlrtra, dattra, codloj) VALUES (@nrocta, @nropla, @vlrtra, @dattra, @codloj)", connection);
                //command.Parameters.AddWithValue("@nrotra", entity.NumeroTransacao);
                command.Parameters.AddWithValue("@nrocta", entity.NumeroConta);
                command.Parameters.AddWithValue("@nropla", entity.NumeroPlastico);
                command.Parameters.AddWithValue("@vlrtra", entity.ValorTransacao);
                command.Parameters.AddWithValue("@dattra", entity.DataTransacao);
                command.Parameters.AddWithValue("@codloj", entity.CodigoEstabelecimento);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Transacao entity)
        {
            // Implementar lógica de atualização
        }

        public Transacao GetById(int id)
        {
            // Implementar lógica de obtenção por ID
            return null;
        }

        public IEnumerable<Transacao> GetAll()
        {
            // Implementar lógica de obtenção de todos os registros
            return new List<Transacao>();
        }
    }

}
