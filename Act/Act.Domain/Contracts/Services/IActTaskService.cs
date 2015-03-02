using Act.Domain.Models;
using System;
using System.Collections.Generic;

namespace Act.Domain.Contracts.Services
{
    public interface IActTaskService : IDisposable
    {
        void RestoreDatabase();
        void SaveDatabase();
        void SaveActTask(ActTask task);
        void DeleteActTask(int id);
        IEnumerable<ActTask> GetActTasks();
    }
}
