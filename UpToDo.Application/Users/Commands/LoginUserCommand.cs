using MediatR;
using UpToDo.Contracts.Users;

namespace UpToDo.Application.Users.Commands;

/// <summary>
/// Команда авторизации пользователя.
/// </summary>
public record LoginUserCommand(string Email, string Password)
    : IRequest<TokenResponse>;