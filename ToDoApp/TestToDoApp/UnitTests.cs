using FakeItEasy;
using System.Collections.Generic;
using ToDoApp.Controllers;
using ToDoApp.DAL;
using ToDoApp.Models;
using Xunit;

namespace TestToDoApp
{
    public class UnitTests
    {
        private ToDoModelsController _controller;
        private readonly IToDoDAL _dal;
        public UnitTests()
        {

            _dal = A.Fake<IToDoDAL>();
            _controller = new ToDoModelsController(_dal);
        }

        [Fact]
        public void GetToDoItems_Success()
        {
            var toDoItems = MockGetData();
            A.CallTo(() => _dal.GetToDoItems()).Returns(toDoItems);

            var actualesult = _controller.GetToDoItems();

            Assert.NotNull(actualesult);
            Assert.Null(actualesult.Exception);
        }

        [Fact]
        public void PostToDoItem_Success()
        {
            var toDoItems = MockGetData();
            ToDoModel item = new ToDoModel
            {
                ItemId = 4,
                ItemName = "Item4",
                ItemDescription = "",
                ItemStatus = false
            };
            A.CallTo(() => _dal.AddItemToDo(A<ToDoModel>.Ignored)).Returns(1);

            var actualesult = _controller.PostToDoItemModel(item);

            Assert.NotNull(actualesult);
            Assert.Null(actualesult.Exception);
        }

        [Fact]
        public void PutToDoItem_Success()
        {
            var toDoItems = MockGetData();
            ToDoModel item = new ToDoModel
            {
                ItemId = 3,
                ItemName = "Item31",
                ItemDescription = "",
                ItemStatus = true
            };
            A.CallTo(() => _dal.UpdateItemToDo(A<int>.Ignored, A<ToDoModel>.Ignored)).Returns(1);

            var actualesult = _controller.PutToDoItemModel(item.ItemId, item);

            Assert.NotNull(actualesult);
            Assert.Null(actualesult.Exception);
        }

        [Fact]
        public void DeleteToDoItem_Success()
        {
            var toDoItems = MockGetData();
            ToDoModel item = new ToDoModel
            {
                ItemId = 3,
                ItemName = "Item4",
                ItemDescription = "",
                ItemStatus = false
            };
            A.CallTo(() => _dal.GetToDoItemById(A<int>.Ignored)).Returns(item);

            A.CallTo(() => _dal.DeleteItemById(A<ToDoModel>.Ignored)).Returns(1);

            var actualesult = _controller.DeleteToDoItemModel(item.ItemId);

            Assert.NotNull(actualesult);
            Assert.Null(actualesult.Exception);
        }

        [Fact]
        public void GetToDoItem_Success()
        {
            var toDoItems = MockGetData();
            ToDoModel item = new ToDoModel
            {
                ItemId = 3,
                ItemName = "Item4",
                ItemDescription = "",
                ItemStatus = false
            };
            A.CallTo(() => _dal.GetToDoItemById(A<int>.Ignored)).Returns(item);

            var actualesult = _controller.GetToDoItemModel(item.ItemId);

            Assert.NotNull(actualesult);
            Assert.Null(actualesult.Exception);
        }

        [Fact]
        public void GetToDoItem_Failure()
        {
            var toDoItems = MockGetData();
            ToDoModel item = null;
            A.CallTo(() => _dal.GetToDoItemById(A<int>.Ignored)).Returns(item);

            var actualesult = _controller.GetToDoItemModel(8);

            Assert.NotNull(actualesult);
            Assert.Null(actualesult.Exception);
            Assert.Null(actualesult.Result.Value);
        }
        public List<ToDoModel> MockGetData()
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
    }
}
