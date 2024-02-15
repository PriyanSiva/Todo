using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoListModels;
using ToDoListAPI.Data;

namespace ToDoListWebAPI.Controllers
{
    public class ToDoController : Controller
    {
        private readonly ToDoDbContext todocontext;

        public ToDoController(ToDoDbContext context)
        {
            this.todocontext = context;
        }
        [HttpGet("/")]
        public async Task<ActionResult<IEnumerable<ToDoItem>>> GetToDoItems()
        {
            // Retrieve ToDoItems with no CompletedDate set
            List<ToDoItem> toDoItems = await todocontext.ToDoItems.Where(item => item.CompletedDate == null).ToListAsync();

            return Ok(toDoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItemById(int id)
        {
            // Retrieve ToDoItem based on the provided Id
            ToDoItem toDoItem = await todocontext.ToDoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            return Ok(toDoItem);
        }

        [HttpPost("/")]
        public async Task<ActionResult<ToDoItem>> CreateToDoItem(ToDoItem toDoItem)
        {

            // Add the new ToDoItem to the database
            todocontext.ToDoItems.Add(toDoItem);
            await todocontext.SaveChangesAsync();

            // Return the newly created ToDoItem
            return CreatedAtAction(nameof(GetToDoItemById), new { id = toDoItem.Id }, toDoItem);
        }

        [HttpPost("{id}/complete")]
        public async Task<ActionResult<ToDoItem>> MarkToDoItemAsCompleted(int id)
        {
            // Find the ToDoItem with the specified Id
            var toDoItem = await todocontext.ToDoItems.FindAsync(id);

            // If ToDoItem is not found, return 404 Not Found
            if (toDoItem == null)
            {
                return NotFound();
            }

            // Update the CompletedDate with the current datetime
            toDoItem.CompletedDate = DateTime.Now;

            // Update the ToDoItem in the database
            todocontext.Entry(toDoItem).State = EntityState.Modified;
            await todocontext.SaveChangesAsync();

            // Return the updated ToDoItem
            return Ok(toDoItem);
        }
    }
}