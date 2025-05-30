namespace UpToDo.Application.Shared.Exceptions;

public class UserNotFoundException() : AppException("Пользователь не найден", 400);