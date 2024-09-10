using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Interfaces
{
    public interface IFileProcessor
    {
        void Process(string directoryPath);
    }
}
