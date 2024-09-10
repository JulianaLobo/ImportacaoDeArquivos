using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Models
{
    public class Plastico
    {
        public string NumeroConta { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string NumeroPlastico { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(NumeroConta) && !string.IsNullOrEmpty(NumeroPlastico);
        }
    }

}
