using ImportacaoDeArquivos.Interfaces;
using ImportacaoDeArquivos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Services
{
    public class PlasticoFileReader : IFileReader<Plastico>
    {
        public List<Plastico> ReadFile(string filePath)
        {
            var plasticos = new List<Plastico>();

            var lines = File.ReadAllLines(filePath);
            foreach (var line in lines.Skip(1)) // Pular o cabeçalho
            {
                var plastico = new Plastico
                {
                    NumeroConta = line.Substring(1, 7).Trim(),
                    Nome = line.Substring(8, 30).Trim(),
                    CPF = line.Substring(38, 11).Trim(),
                    NumeroPlastico = line.Substring(49, 7).Trim()
                };

                if (plastico.IsValid())
                {
                    plasticos.Add(plastico);
                }
            }

            return plasticos;
        }
    }

}
