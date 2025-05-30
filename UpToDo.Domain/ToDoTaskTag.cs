namespace UpToDo.Domain;

/// <summary>
/// Связь между задачей и тегом (многие-ко-многим).
/// </summary>
public class ToDoTaskTag
{
    /// <summary>
    /// Id задачи.
    /// </summary>
    public Guid ToDoTaskId { get; set; }
    public ToDoTask ToDoTask { get; set; } = null!;

    /// <summary>
    /// Id тега.
    /// </summary>
    public Guid TagId { get; set; }
    public Tag Tag { get; set; } = null!;
}