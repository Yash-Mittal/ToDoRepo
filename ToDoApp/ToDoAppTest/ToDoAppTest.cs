using FakeItEasy;
using NUnit.Framework;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Controllers;
using ToDoApp.DAL;
using ToDoApp.Models;

namespace ToDoAppTest
{
    public class Tests
    {
        private ToDoModelsController _controller;
        private readonly IToDoDAL _dal;
        public Tests()
        {
            
            _dal = A.Fake<IToDoDAL>();
            _controller = new ToDoModelsController(_dal);
        }

        [SetUp]
        public void Setup()
        {
        }

        public async Task FakeDataAsync()
        {
            var data = await MockGetData();
           // A.CallTo(() => _dal.GetToDoItems().Returns(data);
        }
        public async Task<List<ToDoModel>> MockGetData()
        {
            List<ToDoModel> ToDoItems = new List<ToDoModel>();
            ToDoModel item1 = new ToDoModel
            {
                ItemId = 1,
                ItemName = "Item1",
                ItemDescription = "",
                ItemStatus = false
            };
            ToDoModel item2 = new ToDoModel
            {
                ItemId = 2,
                ItemName = "Item2",
                ItemDescription = "",
                ItemStatus = true
            };
            ToDoModel item3 = new ToDoModel
            {
                ItemId = 3,
                ItemName = "Item3",
                ItemDescription = "Desc 3",
                ItemStatus = false
            };
            ToDoItems.Add(item1);
            ToDoItems.Add(item2);
            ToDoItems.Add(item3);
            return ToDoItems;
        }

        [Test]
        public async void  GetToDoItems_Success()
        {
            var toDoItems = await MockGetData();
            A.CallTo(() => _dal.GetToDoItems()).Returns(toDoItems);

            var actualesult = _controller.GetToDoItems();

            Assert.NotNull(actualesult);
        }
    }
}