namespace UpToDo.Application.Shared.Exceptions;

public class TasksListNotFoundException() : AppException("Список задач не найден", 400);