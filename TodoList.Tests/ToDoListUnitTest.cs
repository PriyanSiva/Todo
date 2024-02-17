using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoListClassLibrary;
using ToDoListWebAPI.Controllers;

namespace ToDoListUnitTests
{
    [TestClass]
    public class ToDoListUnitTest
    {
        ToDoItem? toDoItem;

        [TestInitialize]
        public void TestInitialize()
        {
            toDoItem = new ToDoListClassLibrary.ToDoItem();
        }


        [TestMethod]
        public void ToDoItem_Initialization_Success()
        {

            Assert.IsNotNull(toDoItem);
        }

        [TestMethod]
        public void ToDoItem_SetDueDate_Success()
        {
            var dueDate = DateTime.Now.AddDays(7);

            toDoItem.DueDate = dueDate;

            Assert.AreEqual(dueDate, toDoItem.DueDate);
        }

        [TestMethod]
        public void ToDoItem_SetCompletedDate_Success()
        {
            var completedDate = DateTime.Now;

            toDoItem.CompletedDate = completedDate;

            Assert.AreEqual(completedDate, toDoItem.CompletedDate);
        }

        [TestMethod]
        public void ToDoItem_SetDescription_Success()
        {
            var description = "Sample description";

            toDoItem.Description = description;

            Assert.AreEqual(description, toDoItem.Description);
        }
    }
}
