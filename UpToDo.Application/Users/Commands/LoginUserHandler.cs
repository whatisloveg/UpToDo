using MediatR;
using UpToDo.Application.Shared.Common;
using UpToDo.Application.Shared.Repositories;
using UpToDo.Contracts.Users;
using UpToDo.Domain;

namespace UpToDo.Application.Users.Commands;

/// <summary>
/// Обработчик авторизации пользователя
/// </summary>
/// <param name="users"></param>
/// <param name="hasher"></param>
/// <param name="jwt"></param>
public class LoginUserHandler(IUsersRepository users, IPasswordHasher hasher, IJwtTokenGenerator jwt)
    : IRequestHandler<LoginUserCommand, TokenResponse>
{
    
    /// <summary>
    /// Авторизует пользователя.
    /// </summary>
    /// <returns>JWT токен авторизации.</returns>
    /// <exception cref="UnauthorizedAccessException">Ошибка авторизации пользователя</exception>
    public async Task<TokenResponse> Handle(
        LoginUserCommand request,
        CancellationToken cancellationToken)
    {
        User? user = await users.GetByEmailAsync(request.Email, cancellationToken);

        if (user is null)
        {
            throw new UnauthorizedAccessException("Пользователь не найден");
        }
        
        bool passwordIsOk = hasher.Verify(request.Password, user.PasswordHash);

        if (!passwordIsOk)
        {
            throw new UnauthorizedAccessException("Неверный пароль");
        }
        
        string token = jwt.Generate(user);
        return new TokenResponse(token, user.Id);
    }
}