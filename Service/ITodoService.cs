using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Service;

public interface ITodoService
{
    public void CreateTodoItem(TodoItemDto todoItem);
    public void DeleteTodoItem(long id);
    public TodoItemDto GetTodoItem(long id);
    public List<TodoItemDto> GetTodoItems();
    public void UpdateTodoItem(TodoItemDto todoItem);
    
}