using MediatR;
using UpToDo.Contracts.Users;

namespace UpToDo.Application.Users.Commands;

/// <summary>
/// Команда регистрации пользователя.
/// </summary>
/// <param name="Name">Имя пользователя.</param>
/// <param name="Email">Почта.</param>
/// <param name="Password">Пароль.</param>
/// <param name="ConfirmPassword">Повтор пароля.</param>
public sealed record RegisterUserCommand(
    string Name,
    string Email,
    string Password,
    string ConfirmPassword)
    : IRequest<TokenResponse>;