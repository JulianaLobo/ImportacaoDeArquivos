using ImportacaoDeArquivos.Interfaces;
using ImportacaoDeArquivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Services
{
    public class TransacaoFileReader : IFileReader<Transacao>
    {
        public List<Transacao> ReadFile(string filePath)
        {
            var transacoes = new List<Transacao>();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Pular o cabeçalho
            {
                var transacao = new Transacao
                {
                    NumeroConta = line.Substring(2, 7).Trim(),
                    NumeroPlastico = line.Substring(8, 7).Trim(),
                    ValorTransacao = decimal.Parse(line.Substring(15, 12)) / 100, // Converter de centavos
                    DataTransacao = DateTime.ParseExact(line.Substring(27, 8), "ddMMyyyy", null),
                    HoraTransacao = TimeSpan.ParseExact(line.Substring(35, 6), "hhmmss", null),
                    CodigoEstabelecimento = line.Substring(41, 6).Trim()
                };

                if (transacao.IsValid())
                {
                    transacoes.Add(transacao);
                }
            }

            return transacoes;
        }
    }

}
