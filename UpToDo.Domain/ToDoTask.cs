using UpToDo.Domain.Enums;

namespace UpToDo.Domain;

/// <summary>
/// Сущность задачи.
/// </summary>
public class ToDoTask
{
    /// <summary>
    /// Id задачи.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название задачи.
    /// </summary>
    public string? Name { get; set; } = string.Empty;
    
    /// <summary>
    /// Описание задачи.
    /// </summary>
    public string? Description { get; set; } = string.Empty;
    
    /// <summary>
    /// Приоритет по матрице Эйзенхауэра
    /// </summary>
    public TaskMatrixPriority MatrixPriority { get; set; } = TaskMatrixPriority.Uncategorized;

    /// <summary>
    /// Время выделенное на задачу.
    /// </summary>
    public decimal? EstimatedTime { get; set; } = null;

    /// <summary>
    /// Выполнена ли задача.
    /// </summary>
    public bool IsCompleted { get; set; }= false;
    
    /// <summary>
    /// Дата создания задачи.
    /// </summary>
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    /// <summary>
    /// Дата завершения задачи.
    /// </summary>
    public DateTime? CompletedAt { get; set; }
    
    /// <summary>
    /// Список подзадач.
    /// </summary>
    public List<Subtask> Subtasks { get; set; } = new();

    /// <summary>
    /// Ссылка на список задач, к которому принадлежит задача.
    /// </summary>
    public Guid TasksListId { get; set; }
    
    /// <summary>
    /// Навигационное свойство для списка задач.
    /// </summary>
    public TasksList? TasksList { get; set; }
    
    /// <summary>
    /// Теги задачи.
    /// </summary>
    public List<ToDoTaskTag> ToDoTaskTags { get; set; } = new();

}