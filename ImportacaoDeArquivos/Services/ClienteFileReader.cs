using ImportacaoDeArquivos.Interfaces;
using ImportacaoDeArquivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Services
{
    public class ClienteFileReader : IFileReader<Cliente>
    {
        public List<Cliente> ReadFile(string filePath)
        {
            var clientes = new List<Cliente>();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Pular o cabeçalho
            {
                var cliente = new Cliente
                {
                    CPF = line.Substring(2, 11).Trim(),
                    Nome = line.Substring(13, 30).Trim(),
                    Endereco = line.Substring(43, 30).Trim(),
                    Bairro = line.Substring(73, 30).Trim(),
                    Cidade = line.Substring(103, 30).Trim(),
                    Estado = line.Substring(133, 2).Trim(),
                    DataCadastro = DateTime.ParseExact(line.Substring(135, 8), "ddMMyyyy", null),
                };

                // Verificar se a hora é válida 
                string horaCadastroStr = line.Substring(143, 6).Trim();
                if (TimeSpan.TryParseExact(horaCadastroStr, "hhmmss", null, out TimeSpan horaCadastro))
                {
                    cliente.HoraCadastro = horaCadastro;
                }
                else
                {
                    // Se o tempo não for válido zerar a hora
                    cliente.HoraCadastro = TimeSpan.Zero; // ou outra lógica
                    Console.WriteLine($"Hora inválida encontrada: {horaCadastroStr}");
                }

                if (cliente.IsValid())
                {
                    clientes.Add(cliente);
                }
            }

            return clientes;
        }

    }

}
