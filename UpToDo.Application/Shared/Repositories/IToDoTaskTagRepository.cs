using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

public interface IToDoTaskTagRepository
{
    Task AddAsync(ToDoTaskTag toDoTaskTag);
    Task<ToDoTaskTag?> GetByIdsAsync(Guid toDoTaskId, Guid tagId);
    Task<List<ToDoTaskTag>> GetByTaskIdAsync(Guid toDoTaskId);
    Task<List<ToDoTaskTag>> GetByTagIdAsync(Guid tagId);
    Task DeleteAsync(Guid toDoTaskId, Guid tagId);
}