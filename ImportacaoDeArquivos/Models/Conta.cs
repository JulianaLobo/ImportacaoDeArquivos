using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Models
{
    public class Conta
    {
        public string CPF { get; set; }
        public decimal ValorLimite { get; set; }
        public int DiaVencimento { get; set; }
        public string NumeroConta { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(CPF) && !string.IsNullOrEmpty(NumeroConta);
        }
    }

}
