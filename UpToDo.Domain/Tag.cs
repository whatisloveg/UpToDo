namespace UpToDo.Domain;

/// <summary>
/// Сущность тега для задач.
/// </summary>
public class Tag
{
    public Guid Id { get; set; }
    
    public string Name { get; set; } = string.Empty;
    
    public List<ToDoTaskTag> ToDoTaskTags { get; set; } = new();
    
    public Guid UserId { get; set; }                
    public User User { get; set; } = null!;        
}