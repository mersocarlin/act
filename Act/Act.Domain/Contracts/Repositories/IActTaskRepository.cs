using Act.Domain.Models;
using System;
using System.Collections.Generic;

namespace Act.Domain.Contracts.Repositories
{
    public interface IActTaskRepository : IDisposable
    {
        void Insert(ActTask task);
        void Update(ActTask task);
        void Delete(ActTask task);
        ActTask Get(int id);
        IEnumerable<ActTask> Get();
    }
}
