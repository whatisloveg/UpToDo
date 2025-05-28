namespace UpToDo.Domain;

/// <summary>
/// Сущность списка задач
/// </summary>
public class TasksList
{
    /// <summary>
    /// Id списка задач
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Название списка задач.
    /// </summary>
    public string Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Дата создания списка задач.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Задачи в списке
    /// </summary>
    public List<ToDoTask> Tasks { get; set; } = new();
    
    /// <summary>
    /// Id пользователя, которому принадлежит список задач.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Навигационное свойство для пользователя.
    /// </summary>
    public User? User { get; set; }
}