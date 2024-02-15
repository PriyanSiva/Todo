using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace TodoListModels
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? Description { get; set; }

        public ToDoItem()
        {
            // Set DueDate to be 1 week from now if it's initially null
            if (DueDate == default)
            {
                DueDate = DateTime.Now.AddDays(7);
            }
        }
    }
}