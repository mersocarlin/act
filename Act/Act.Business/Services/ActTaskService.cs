using Act.Domain.Contracts.Repositories;
using Act.Domain.Contracts.Services;
using Act.Domain.Models;
using System;
using System.Collections.Generic;

namespace Act.Business.Services
{
    public class ActTaskService : IActTaskService
    {
        private IActTaskRepository _repository;
        private Random _rand;

        public ActTaskService(IActTaskRepository repository)
        {
            this._repository = repository;
            this._rand = new Random();
        }

        public void RestoreDatabase()
        {
            _repository.RestoreDatabase();
        }

        public void SaveDatabase()
        {
            _repository.SaveDatabase();
        }

        public void SaveActTask(ActTask task)
        {
            task.Validate();
            if (task.Id == 0)
            {
                task.Id = _rand.Next(0, 10000000);
                _repository.Insert(task);
            }
            else if (_repository.Get(task.Id) != null)
                _repository.Update(task);
            else
                throw new Exception(string.Format("TaskId {0} not found", task.Id));
        }

        public void DeleteActTask(int id)
        {
            var task = _repository.Get(id);
            if (task == null)
                throw new Exception(string.Format("TaskId {0} not found", id));
            _repository.Delete(task);
        }

        public IEnumerable<ActTask> GetActTasks()
        {
            return _repository.Get();
        }

        public void Dispose()
        {
            this._repository.Dispose();
        }
    }
}
