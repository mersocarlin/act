using Act.Domain.Contracts.Repositories;
using Act.Domain.Models;
using System.Collections.Generic;
using System.Linq;

namespace Act.Data.Repository
{
    public class ActTaskRepository : IActTaskRepository
    {
        private List<ActTask> myDatabase;

        public ActTaskRepository()
        {
            this.myDatabase = new List<ActTask>();
        }

        public void RestoreDatabase()
        {

        }

        public void SaveDatabase()
        {

        }

        public void Insert(ActTask task)
        {
            myDatabase.Add(task);
        }

        public void Update(ActTask task)
        {
            var taskDb = Get(task.Id);
            taskDb.Title = task.Title;
            taskDb.Description = task.Description;
            taskDb.ParentId = task.ParentId;
        }

        public void Delete(ActTask task)
        {
            myDatabase.Remove(task);
        }

        public ActTask Get(int id)
        {
            return myDatabase.Where(t => t.Id == id).FirstOrDefault();
        }

        public IEnumerable<ActTask> Get()
        {
            return myDatabase;
        }

        public void Dispose()
        {
            myDatabase.Clear();
            myDatabase = null;
        }
    }
}
