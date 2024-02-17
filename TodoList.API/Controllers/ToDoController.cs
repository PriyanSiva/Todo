using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListClassLibrary;
using ToDoListWebAPI.Data;

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
            List<ToDoItem> toDoItems = await todocontext.ToDoItems.Where(item => item.CompletedDate == null).ToListAsync();

            return Ok(toDoItems);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoItem>> GetToDoItemById(int id)
        {
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
            todocontext.ToDoItems.Add(toDoItem);
            await todocontext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetToDoItemById), new { id = toDoItem.Id }, toDoItem);
        }

        [HttpPost("{id}/complete")]
        public async Task<ActionResult<ToDoItem>> MarkToDoItemAsCompleted(int id)
        {
            var toDoItem = await todocontext.ToDoItems.FindAsync(id);

            if (toDoItem == null)
            {
                return NotFound();
            }

            toDoItem.CompletedDate = DateTime.Now;
            todocontext.Entry(toDoItem).State = EntityState.Modified;
            await todocontext.SaveChangesAsync();

            return Ok(toDoItem);
        }
    }
}
