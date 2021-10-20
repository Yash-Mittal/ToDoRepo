using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ToDoApp.Models;

namespace ToDoApp.DAL
{
    public class ToDoDAL : IToDoDAL
    {
        private readonly ApplicationDbContext _context;
        public ToDoDAL(ApplicationDbContext context)
        {
            _context = context;
        }
        Task<int> IToDoDAL.AddItemToDo(ToDoModel toDoItemModel)
        {
            _context.ToDoItems.Add(toDoItemModel);
            return _context.SaveChangesAsync();
        }

        Task<int> IToDoDAL.DeleteItemById(ToDoModel toDoItemModel)
        {
            _context.ToDoItems.Remove(toDoItemModel);
            return _context.SaveChangesAsync();
        }

        async Task<ToDoModel> IToDoDAL.GetToDoItemById(int id)
        {
            return await _context.ToDoItems.FindAsync(id);
        }

        Task<List<ToDoModel>> IToDoDAL.GetToDoItems()
        {
            return _context.ToDoItems.ToListAsync();
        }

        bool IToDoDAL.ToDoItemModelExists(int id)
        {
            return _context.ToDoItems.Any(e => e.ItemId == id);
        }

        Task<int> IToDoDAL.UpdateItemToDo(int id, ToDoModel toDoItemModel)
        {
            _context.Entry(toDoItemModel).State = EntityState.Modified;
            return _context.SaveChangesAsync();
        }
    }
}
