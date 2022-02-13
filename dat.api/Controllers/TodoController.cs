using Microsoft.AspNetCore.Mvc;
namespace dat.api.Controllers;

[ApiController]
[Route("[controller]")]
public class TodoController : ControllerBase
{

    private readonly DataContext context;

    public TodoController(DataContext context)
    {
        this.context = context;
    }

    [HttpGet]
    public async Task<ActionResult<Todo>> Get()
    {

        return Ok(await context.Todos.ToListAsync());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Todo>> Get(int id)
    {
        var todoItem = await context.Todos.FindAsync(id);
        if (todoItem == null)
            return BadRequest("Todo not found.");

        return Ok(todoItem);
    }

    [HttpPost]
    public async Task<IActionResult> Post(Todo todoItem)
    {
        context.Todos.Add(todoItem);
        await context.SaveChangesAsync();
        return Ok();
    }

    [HttpPatch()]
    public async Task<IActionResult> Patch(Todo todoItem)
    {

        var todoUpd = await context.Todos.FindAsync(todoItem.Id);
        if (todoUpd == null) return BadRequest("Todo not found");

        todoUpd.Description = todoItem.Description;
        if (todoUpd.PlannedDate != null) todoUpd.PlannedDate = todoItem.PlannedDate;
        if (todoUpd.Status != null) todoUpd.Status = todoItem.Status;

        await context.SaveChangesAsync();

        return Ok(todoUpd);

    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var todoItem = await context.Todos.FindAsync(id);
        if (todoItem == null)
            return BadRequest("Todo not found.");

        context.Todos.Remove(todoItem);
        await context.SaveChangesAsync();
        return Ok(todoItem);
    }

}