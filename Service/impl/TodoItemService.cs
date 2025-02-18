using WebAPI.DTOs;
using WebAPI.Models;

namespace WebAPI.Service.impl;

public class TodoItemService : ITodoService
{
    private readonly TodoContext _context;
    private readonly ILogger _logger;

    public TodoItemService(TodoContext context, ILogger<TodoItem> logger)
    {
        _context = context;
        _logger = logger;
    }

    public void CreateTodoItem(TodoItemDto todoItem)
    {
        _logger.Log(LogLevel.Information, "Creating todo item");
        var todoItemModel = MapToTodoItem(todoItem);
        _context.TodoItems.Add(todoItemModel);
        _context.SaveChanges();
        _logger.Log(LogLevel.Information, "Todo item created");
    }

    public void DeleteTodoItem(long id)
    {
        _logger.Log(LogLevel.Information, "Deleting todo item");
        var todoItem = _context.TodoItems.Find(id);
        if (todoItem == null)
        {
            _logger.Log(LogLevel.Error, "Todo item not found");
            return;
        }
        _context.TodoItems.Remove(todoItem);
        _context.SaveChanges();
        _logger.Log(LogLevel.Information, "Todo item deleted");
    }

    public TodoItemDto GetTodoItem(long id)
    {
        _logger.Log(LogLevel.Information, "Getting todo item");
        var todoItem = _context.TodoItems.Find(id);
        if (todoItem == null)
        {
            _logger.Log(LogLevel.Error, "Todo item not found");
            return null;
        }
        return MapToTodoItemDto(todoItem);
    }

    public List<TodoItemDto> GetTodoItems()
    {
        _logger.Log(LogLevel.Information, "Getting todo items");
        var todoItems = _context.TodoItems.ToList();
        return todoItems.Select(MapToTodoItemDto).ToList();
    }

    public void UpdateTodoItem(TodoItemDto todoItem)
    {
        _logger.Log(LogLevel.Information, "Updating todo item");
        var todoItemModel = MapToTodoItem(todoItem);
        _context.TodoItems.Update(todoItemModel);
        _context.SaveChanges();
        _logger.Log(LogLevel.Information, "Todo item updated");
    }
    
    private TodoItem MapToTodoItem(TodoItemDto todoItemDto)
    {
        return new TodoItem
        {
            Id = todoItemDto.Id,
            Name = todoItemDto.Name,
            IsComplete = todoItemDto.IsComplete
        };
    }
    
    private TodoItemDto MapToTodoItemDto(TodoItem todoItem)
    {
        return new TodoItemDto
        {
            Id = todoItem.Id,
            Name = todoItem.Name,
            IsComplete = todoItem.IsComplete
        };
    }
}