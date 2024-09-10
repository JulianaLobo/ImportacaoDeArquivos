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
    public class PlasticoRepository : IDataRepository<Plastico>
    {
        private readonly string _connectionString;

        public PlasticoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Insert(Plastico entity)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var command = new NpgsqlCommand("INSERT INTO tbplastico (nropla, nrocta, nompla, cpfpla) VALUES (@nropla, @nrocta, @nompla, @cpfpla)", connection);
                command.Parameters.AddWithValue("@nropla", entity.NumeroPlastico);
                command.Parameters.AddWithValue("@nrocta", entity.NumeroConta);
                command.Parameters.AddWithValue("@nompla", entity.Nome);
                command.Parameters.AddWithValue("@cpfpla", entity.CPF);
                command.ExecuteNonQuery();
            }
        }

        public void Update(Plastico entity)
        {
            // Implementar lógica de atualização
        }

        public Plastico GetById(int id)
        {
            // Implementar lógica de obtenção por ID
            return null;
        }

        public IEnumerable<Plastico> GetAll()
        {
            // Implementar lógica de obtenção de todos os registros
            return new List<Plastico>();
        }
    }

}
