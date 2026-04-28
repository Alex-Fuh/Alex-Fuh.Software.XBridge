using Alex_Fuh.Software.XBridge.Dto;

namespace Alex_Fuh.Software.XBridge.Service.Interface;

public interface ITodoService
{
    Task<TodoResponse> CreateAsync(CreateTodoRequest request);

    Task<List<TodoResponse>> GetAllAsync();
}