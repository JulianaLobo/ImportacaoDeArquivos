using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Models
{
    public class Transacao
    {
        public string NumeroTransacao { get; set; }
        public string NumeroConta { get; set; }
        public string NumeroPlastico { get; set; }
        public decimal ValorTransacao { get; set; }
        public DateTime DataTransacao { get; set; }
        public TimeSpan HoraTransacao { get; set; }
        public string CodigoEstabelecimento { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrEmpty(NumeroConta) && ValorTransacao > 0;
        }
    }

}
