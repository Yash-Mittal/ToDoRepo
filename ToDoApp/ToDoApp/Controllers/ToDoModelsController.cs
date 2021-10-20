using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoApp.DAL;
using ToDoApp.Models;

namespace ToDoApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoModelsController : Controller
    {
        private readonly IToDoDAL _dal;

        public ToDoModelsController(IToDoDAL dal)
        {
            _dal = dal;
        }

        // GET: ToDoModels
        // GET: api/ToDoItem
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ToDoModel>>> GetToDoItems()
        {
            return await _dal.GetToDoItems();
        }

        // GET: api/ToDoItem/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ToDoModel>> GetToDoItemModel(int id)
        {
            //var data = _dal.GetToDoItemById(id);
            var toDoItemModel = await _dal.GetToDoItemById(id);

            if (toDoItemModel == null)
            {
                return NotFound();
            }

            return toDoItemModel;
        }

        // PUT: api/ToDoItem/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutToDoItemModel(int id, ToDoModel toDoItemModel)
        {
            if (id != toDoItemModel.ItemId)
            {
                return BadRequest();
            }

           
            try
            {
                await _dal.UpdateItemToDo(id, toDoItemModel);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ToDoItemModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ToDoItem
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ToDoModel>> PostToDoItemModel(ToDoModel toDoItemModel)
        {
            await _dal.AddItemToDo(toDoItemModel);
            return CreatedAtAction("GetToDoItemModel", new { id = toDoItemModel.ItemId }, toDoItemModel);
        }

        // DELETE: api/ToDoItem/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteToDoItemModel(int id)
        {
            var toDoItemModel = await _dal.GetToDoItemById(id);
            if (toDoItemModel == null)
            {
                return NotFound();
            }

            await _dal.DeleteItemById(toDoItemModel);

            return NoContent();
        }

        private bool ToDoItemModelExists(int id)
        {
            return _dal.ToDoItemModelExists(id);
        }
    }
}