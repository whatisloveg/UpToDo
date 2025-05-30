namespace UpToDo.Domain;

/// <summary>
/// Сущность тега для задач.
/// </summary>
public class Tag
{
    /// <summary>
    /// Id тега.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Название тега.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Список связей с задачами (многие-ко-многим).
    /// </summary>
    public List<ToDoTaskTag> ToDoTaskTags { get; set; } = new();
    
    public Guid UserId { get; set; }                
    public User User { get; set; } = null!;        
}