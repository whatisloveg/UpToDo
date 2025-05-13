namespace UpToDo.Application.Shared.Exceptions;

public class TaskNotFoundException() : AppException("Задача не найдена", 400);