using UpToDo.Domain.Enums;

namespace UpToDo.Domain;

/// <summary>
/// Сущность задачи.
/// </summary>
public class ToDoTask
{

    public Guid Id { get; set; }

    public string? Name { get; set; } = string.Empty;

    public string? Description { get; set; } = string.Empty;
    

    public TaskMatrixPriority? MatrixPriority { get; set; } = TaskMatrixPriority.Uncategorized;


    public decimal? EstimatedTime { get; set; } = null;


    public bool IsCompleted { get; set; }= false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? CompletedAt { get; set; }

    public List<Subtask> Subtasks { get; set; } = new();

    public Guid TasksListId { get; set; }

    public TasksList? TasksList { get; set; }

    public List<ToDoTaskTag> ToDoTaskTags { get; set; } = new();

}