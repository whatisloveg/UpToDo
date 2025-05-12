namespace UpToDo.Domain.Enums;

/// <summary>
/// Перечисление для приоритетов задач в матрице Эйзенхауэра с числовыми значениями.
/// </summary>
public enum TaskMatrixPriority
{
    /// <summary>
    /// Срочная и важная задача.
    /// </summary>
    UrgentAndImportant = 1,

    /// <summary>
    /// Несрочная, но важная задача.
    /// </summary>
    NotUrgentButImportant = 2,

    /// <summary>
    /// Срочная, но не важная задача.
    /// </summary>
    UrgentButNotImportant = 3,

    /// <summary>
    /// Не срочная и не важная задача.
    /// </summary>
    NotUrgentAndNotImportant = 4,

    /// <summary>
    /// Задача, не отнесенная к одной из секций.
    /// </summary>
    Uncategorized = 5
}