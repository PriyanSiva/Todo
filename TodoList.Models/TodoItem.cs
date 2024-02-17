namespace ToDoListClassLibrary
{
    public class ToDoItem
    {
        public int Id { get; set; }
        public DateTime? DueDate { get; set; }
        public DateTime? CompletedDate { get; set; }
        public string? Description { get; set; }

        public ToDoItem()
        {
            if (DueDate == default)
            {
                DueDate = DateTime.Now.AddDays(7);
            }
        }
    }
}
