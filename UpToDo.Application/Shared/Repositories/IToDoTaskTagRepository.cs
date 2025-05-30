using UpToDo.Domain;

namespace UpToDo.Application.Shared.Repositories;

public interface IToDoTaskTagRepository
{
    Task AddAsync(ToDoTaskTag toDoTaskTag);
    Task<ToDoTaskTag?> GetByIdsAsync(Guid taskId, Guid tagId);
    Task<List<ToDoTaskTag>> GetByTaskIdAsync(Guid taskId);
    Task DeleteAsync(Guid taskId, Guid tagId);
}