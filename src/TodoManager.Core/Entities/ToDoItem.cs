using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using TodoManager.Core.SharedKernel;

namespace TodoManager.Core.Entities
{
    public class ToDoItem : Entity
    {
        public string Title { get; set; }
        public string Description { get; set; }

        [DataType(DataType.Date)]
        public DateTime DueDate { get; set; }
        public bool IsDone { get; set; }
    }
}