namespace UpToDo.Domain;

/// <summary>
/// Подзадача или шаг задачи.
/// </summary>
public class Subtask
{

    public Guid Id { get; set; }
    
    public string? Name { get; set; } = string.Empty;

    public bool IsCompleted { get; set; } = false;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

    public DateTime? CompletedAt { get; set; }
    

    public Guid ToDoTaskId { get; set; }

    public ToDoTask? ToDoTask { get; set; }
}