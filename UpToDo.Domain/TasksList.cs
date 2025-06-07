namespace UpToDo.Domain;

/// <summary>
/// Сущность списка задач
/// </summary>
public class TasksList
{

    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    public List<ToDoTask> Tasks { get; set; } = new();
    
    public Guid UserId { get; set; }
    
    public User? User { get; set; }
}