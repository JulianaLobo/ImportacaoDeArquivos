using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Models
{
    public class Cliente
    {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public DateTime DataCadastro { get; set; }
        public TimeSpan HoraCadastro { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(CPF) && !string.IsNullOrEmpty(Nome);
        }
    }

}
