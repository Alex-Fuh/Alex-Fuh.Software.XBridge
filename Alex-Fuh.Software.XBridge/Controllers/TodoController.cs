using Alex_Fuh.Software.XBridge.Dto;
using Alex_Fuh.Software.XBridge.Service.Interface;
using Microsoft.AspNetCore.Mvc;

namespace Alex_Fuh.Software.XBridge.Controllers;

[ApiController]
[Route("api/[controller]")]
public class TodosController : ControllerBase
{
    private readonly ITodoService _todoService;

    public TodosController(ITodoService todoService)
    {
        _todoService = todoService;
    }

    [HttpPost]
    public async Task<ActionResult<TodoResponse>> Create(CreateTodoRequest request)
    {
        var createdTodo = await _todoService.CreateAsync(request);

        return Ok(createdTodo);
    }

    [HttpGet]
    public async Task<ActionResult<List<TodoResponse>>> GetAll()
    {
        var todos = await _todoService.GetAllAsync();

        return Ok(todos);
    }
}