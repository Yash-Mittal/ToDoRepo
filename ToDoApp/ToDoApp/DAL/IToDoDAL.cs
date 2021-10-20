using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.DAL
{
    public interface IToDoDAL
    {
        Task<List<ToDoModel>> GetToDoItems();

        Task<ToDoModel> GetToDoItemById(int id);

        Task<int> UpdateItemToDo(int id, ToDoModel toDoItemModel);

        Task<int> AddItemToDo(ToDoModel toDoItemModel);

        Task<int> DeleteItemById(ToDoModel toDoItemModel);

        bool ToDoItemModelExists(int id);
    }
}
