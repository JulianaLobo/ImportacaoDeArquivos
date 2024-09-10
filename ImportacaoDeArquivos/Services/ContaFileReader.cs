using ImportacaoDeArquivos.Interfaces;
using ImportacaoDeArquivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Services
{
    public class ContaFileReader : IFileReader<Conta>
    {
        public List<Conta> ReadFile(string filePath)
        {
            var contas = new List<Conta>();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Pular o cabeçalho
            {
                var conta = new Conta
                {
                    CPF = line.Substring(2, 11).Trim(),
                    // Verifica se o valor de 'ValorLimite' é um número válido antes de tentar converter
                    ValorLimite = decimal.TryParse(line.Substring(13, 12).Trim(), out decimal valorLimite) ? valorLimite / 100 : 0, // Converte de centavos
                    DiaVencimento = int.TryParse(line.Substring(25, 2).Trim(), out int diaVencimento) ? diaVencimento : 0,
                    NumeroConta = line.Substring(27, 7).Trim()
                };

                if (conta.IsValid())
                {
                    contas.Add(conta);
                }
            }

            return contas;
        }

    }

}
