using System;
using System.Collections.Generic;
namespace Act.Domain.Models
{
    public class ActTask
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
        
        public virtual ActTask Parent { get; set; }
        public virtual IEnumerable<ActTask> ChildTasks { get; set; }

        public ActTask(string title, string description)
        {
            this.Title = title;
            this.Description = description;
            this.ChildTasks = new List<ActTask>();
        }

        public void Validate()
        {
            if (string.IsNullOrEmpty(this.Title))
                throw new Exception("Please fill the Title property");
            if (string.IsNullOrEmpty(this.Description))
                throw new Exception("Please fill the Description property");
        }

        public override string ToString()
        {
            return string.Format("Task Id: {0}, Title: {1}, Description: {2}", this.Id, this.Title, this.Description);
        }
    }
}
