using Microsoft.AspNetCore.Mvc;
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
    public ActionResult<List<TodoItemDto>> GetTodoItems()
    {
        _logger.Log(LogLevel.Information, "Getting todo items");
        return new OkObjectResult(_todoService.GetTodoItems());
    }
    
    [HttpGet("/{id}")]
    public ActionResult<TodoItemDto> GetTodoItem(string id)
    {
        _logger.Log(LogLevel.Information, "Getting todo item");
        return new OkObjectResult(_todoService.GetTodoItem(long.Parse(id)));
    }
    
    [HttpPost]
    public ActionResult<string> CreateTodoItem(TodoItemDto todoItem)
    {
        _logger.Log(LogLevel.Information, "Creating todo item");
        _todoService.CreateTodoItem(todoItem);
        return new OkObjectResult("Todo item created");
    }
    
    [HttpPut]
    public ActionResult<string> UpdateTodoItem(TodoItemDto todoItem)
    {
        _logger.Log(LogLevel.Information, "Updating todo item");
        _todoService.UpdateTodoItem(todoItem);
        return new OkObjectResult("Todo item updated");
    }
    
    [HttpDelete("/{id}")]
    public ActionResult<string> DeleteTodoItem(string id)
    {
        _logger.Log(LogLevel.Information, "Deleting todo item");
        _todoService.DeleteTodoItem(long.Parse(id));
        return new OkObjectResult("Todo item deleted");
    }
}