namespace UpToDo.Application.Shared.Exceptions;

/// <summary>
/// Ошибка о существовании email при регистрации 
/// </summary>
public class EmailAlreadyExistsException()
    : AppException("Пользователь с таким email уже существует", 409);