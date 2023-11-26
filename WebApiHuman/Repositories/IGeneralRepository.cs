using System.Collections.Generic;
using System.Threading;
using System;
using System.Threading.Tasks;
using WebApiHumanModels.Data;

namespace WebApiHuman.Repositories
{
    public interface IGeneralRepository<T>
    {
        Task<T> Create(T addmodel);
        Task<T> Update(T updatemdel);
        Task<T> Get(int id);
        Task<List<T>> GetAll();
    }
}
