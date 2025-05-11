namespace UpToDo.Application.Shared.Exceptions;

/// <summary>
/// Ошибка несовпадения паролей
/// </summary>
public class PasswordsDoNotMatchException() 
    : AppException("Пароли не совпадают", 400);