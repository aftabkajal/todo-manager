using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TodoManager.Core.SharedKernel;

namespace TodoManager.Core.Entities
{
    public class ToDoItem : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}