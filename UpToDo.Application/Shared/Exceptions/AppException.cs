namespace UpToDo.Application.Shared.Exceptions;


/// <summary>
/// Базовая ошибка
/// </summary>
/// <param name="message">Сообщение ошибки.</param>
/// <param name="statusCode">Код ответа сервера.</param>
public abstract class AppException(string message, int statusCode = 500) : Exception(message)
{
    public int StatusCode { get; } = statusCode;
}