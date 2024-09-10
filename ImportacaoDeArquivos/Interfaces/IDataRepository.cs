using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImportacaoDeArquivos.Interfaces
{
    public interface IDataRepository<T>
    {
        void Insert(T entity);
        void Update(T entity);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}
