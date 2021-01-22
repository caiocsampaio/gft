using System;
using System.Collections.Generic;
using System.Text;

namespace GFT.Repository.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        IEnumerable<T> GetAll();

        T Get(int id);

        bool Put(int id, T data);

        int Post(T data);

        bool Delete(T data);

        bool Delete(int id);

    }
}
