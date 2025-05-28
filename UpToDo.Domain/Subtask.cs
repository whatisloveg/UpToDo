namespace UpToDo.Domain;

/// <summary>
/// Подзадача или шаг задачи.
/// </summary>
public class Subtask
{
    /// <summary>
    /// Id подзадачи.
    /// </summary>
    public Guid Id { get; set; }
    
    /// <summary>
    /// Имя подзадачи.
    /// </summary>
    public string? Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Выполнена ли подзадача.
    /// </summary>
    public bool IsCompleted { get; set; } = false;
    
    /// <summary>
    /// Дата создания подзадача.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Дата завершения подзадача.
    /// </summary>
    public DateTime? CompletedAt { get; set; }
    
    /// <summary>
    /// Ссылка на задачу, к которой относится подзадача.
    /// </summary>
    public Guid ToDoTaskId { get; set; }

    /// <summary>
    /// Навигационное свойство для задачи.
    /// </summary>
    public ToDoTask? ToDoTask { get; set; }
}