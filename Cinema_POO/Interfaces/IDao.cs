using System.Collections.Generic;

namespace ConexaoBancoDados.Interfaces
{
    internal interface IDao<T>
    {
        void Create(T obj);
        void Update(T obj);
        void Delete(int id);
        List<T> GetAll();
    }
}
