using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using WebAPI.DTOs;
using WebAPI.Models;
using WebAPI.Service;

namespace WebAPI.Controllers;

[Route("api/todo-item")]
[ApiController]
public class TodoItemController
{
    private readonly ITodoService _todoService;
    private readonly ILogger _logger;

    public TodoItemController(ITodoService todoService, ILogger<TodoItem> logger)
    {
        _todoService = todoService;
        _logger = logger;
    }
    
    [HttpGet]
    public List<TodoItemDto> GetTodoItems()
    {
        _logger.Log(LogLevel.Information, "Getting todo items");
        return _todoService.GetTodoItems();
    }
    
    [HttpGet("/{id}")]
    public TodoItemDto GetTodoItem(string id)
    {
        _logger.Log(LogLevel.Information, "Getting todo item");
        return _todoService.GetTodoItem(long.Parse(id));
    }
}