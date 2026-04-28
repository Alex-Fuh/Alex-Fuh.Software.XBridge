using Alex_Fuh.Software.XBridge.Data.Database;
using Alex_Fuh.Software.XBridge.Dto;
using Alex_Fuh.Software.XBridge.Service.Interface;
using Microsoft.EntityFrameworkCore;

namespace Alex_Fuh.Software.XBridge.Service;

public class TodoService : ITodoService
{
    private readonly XBridgeDbContext _dbContext;

    public TodoService(XBridgeDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<TodoResponse> CreateAsync(CreateTodoRequest request)
    {
        var todo = new Todo
        {
            Title = request.Title
        };

        _dbContext.Todos.Add(todo);
        await _dbContext.SaveChangesAsync();

        return new TodoResponse
        {
            Id = todo.Id,
            Title = todo.Title
        };
    }

    public async Task<List<TodoResponse>> GetAllAsync()
    {
        return await _dbContext.Todos
            .Select(todo => new TodoResponse
            {
                Id = todo.Id,
                Title = todo.Title
            })
            .ToListAsync();
    }
}